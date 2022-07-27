﻿using Amazon.S3;
using Amazon.S3.Model;

namespace Amazon.Lambda.S3Events;

public static class AmazonS3ClientExtensions
{
    public static async Task CopyFolderAsync(this IAmazonS3 amazonS3, string sourceBucket,
        string sourceFolder,
        string destinationBucket,
        string destinationFolder,
        CancellationToken cancellationToken = default(CancellationToken))
    {
        var listObjectsV2Response = await amazonS3.ListObjectsV2Async(new ListObjectsV2Request(), cancellationToken);

        listObjectsV2Response.S3Objects.ForEach(o => amazonS3.CopyObjectAsync(o.BucketName, o.Key, string.Empty, String.Empty, cancellationToken));
    }
}