import pulumi
import pulumi_aws as aws

log_bucket = aws.s3.Bucket("logBucket", acl="log-delivery-write")

bucket = aws.s3.Bucket("bucket",
acl="private",
    tags={
        "Environment": "Stage",
         "Name": "PREPROD",
    },
    loggings=[aws.s3.BucketLoggingArgs(
        target_bucket = log_bucket.id,
        target_prefix= "log/",
    )]
    )
