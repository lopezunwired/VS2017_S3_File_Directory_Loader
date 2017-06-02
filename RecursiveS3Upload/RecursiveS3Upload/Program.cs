using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Amazon;
using Amazon.S3;
using Amazon.S3.Transfer;


// Add using statements to access AWS SDK for .NET services. 
// Both the Service and its Model namespace need to be added 
// in order to gain access to a service. For example, to access
// the EC2 service, add:
// using Amazon.EC2;
// using Amazon.EC2.Model;  this Model is unnecessary

namespace PaulsUploaderS3
{
    class Program
    {
        static string existingBucketName = "YourBucketName"; // only need S3 bucket name MyS3FilesBucket etc.
        static string directoryPath = "c:\\users\\public\\Uploads\\TopLevelDirectory"; // proper formatting of directory escape chars for long names
        public static void Main(string[] args)
        {
            try
            {
                TransferUtility directoryTransferUtility =
                    new TransferUtility(new AmazonS3Client(Amazon.RegionEndpoint.USWest2)); // make sure to select the region

                // 1. Upload a directory with recursive 
                directoryTransferUtility.UploadDirectory(directoryPath,
                                                         existingBucketName, "*.*", SearchOption.AllDirectories);
                Console.WriteLine("Paul your Upload statement 1 has completed");

            }

            catch (AmazonS3Exception e)
            {
                Console.WriteLine(e.Message, e.InnerException);
            }
        }

    }
}