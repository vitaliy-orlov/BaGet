﻿using BaGet.Core.Protocol.Abstractions;
using BaGet.Core.Protocol.Common.Enums;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace BaGet.Core.Protocol.Storage.FileSystem.Internal
{
    /// <summary>
    /// Stores content on disk.
    /// </summary>
    public class FileStorageService : IStorageService
    {
        // See: https://github.com/dotnet/corefx/blob/master/src/Common/src/CoreLib/System/IO/Stream.cs#L35
        private const int DefaultCopyBufferSize = 81920;

        private readonly string _storePath;

        public FileStorageService(string storePath)
        {
            _storePath = storePath ?? throw new ArgumentNullException(nameof(storePath));
        }

        public Task<Stream> GetAsync(string path, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();

            path = GetFullPath(path);
            var content = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.Read);

            return Task.FromResult<Stream>(content);
        }

        public Task<Uri> GetDownloadUriAsync(string path, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var result = new Uri(GetFullPath(path));

            return Task.FromResult(result);
        }

        public async Task<PutResultType> PutAsync(
            string path,
            Stream content,
            string contentType,
            CancellationToken cancellationToken = default)
        {
            if (content == null) throw new ArgumentNullException(nameof(content));
            if (string.IsNullOrEmpty(contentType)) throw new ArgumentException("Content type is required", nameof(contentType));

            cancellationToken.ThrowIfCancellationRequested();

            path = GetFullPath(path);

            // Ensure that the path exists.
            Directory.CreateDirectory(Path.GetDirectoryName(path));

            try
            {
                using (var fileStream = File.Open(path, FileMode.CreateNew))
                {
                    await content.CopyToAsync(fileStream, DefaultCopyBufferSize, cancellationToken);
                    return PutResultType.Success;
                }
            }
            catch (IOException) when (File.Exists(path))
            {
                using (var targetStream = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    return content.Matches(targetStream)
                        ? PutResultType.AlreadyExists
                        : PutResultType.Conflict;
                }
            }
        }

        public Task DeleteAsync(string path, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();

            try
            {
                File.Delete(GetFullPath(path));
            }
            catch (DirectoryNotFoundException)
            {
            }

            return Task.CompletedTask;
        }

        private string GetFullPath(string path)
        {
            // TODO: This should check that the result is in _storePath for security.
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentException("Path is required", nameof(path));
            }

            return Path.Combine(_storePath, path);
        }
    }
}
