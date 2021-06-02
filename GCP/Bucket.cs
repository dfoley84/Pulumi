using Pulumi;
using Gcp = Pulumi.Gcp.Storage;

class MyStack : stack 
{

public MyStack()
{
    var bucket = new Bucket("Dev-Storage", new Gcp.BucketArgs {
        label = new InputMap<String> {
            ["declarative"] = "Dev"
        }

        ForceDestroy = true
    });

    this.BucketName = bucket.Url;
}

[Output]
public Output<string> BucketName { get; set; }
}
