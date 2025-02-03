using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;
using System.Net.Mail;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Xml;

using Microsoft.Graph;
using Microsoft.Graph.Models;
using Microsoft.Graph.Models.ODataErrors;

using Azure.Core;
using Azure.Identity;
using Azure.Core.Pipeline;

using AttachmentUpload = Microsoft.Graph.Me.Messages.Item.Attachments.CreateUploadSession;

 

// Note:
// You will need to create an Applicatoin registration for oAuth App flow and
// grant create and send permissions and do an admin grant for this to work.
// Pull in Azure.Identity and Microsoft.Graph Nuget packages.
// You will need a large file if you want to test for files above 3MB - pictures work well for this.

namespace WinFormGraph4SendEmailWithAttatchement
{
    public partial class Form1 : Form
    {
        private bool _SendToFiddler = false;
        private bool _LogToFile = false;

        private string _ClientAppId = string.Empty;
        private string _TenantId = string.Empty;
        private string _ClientSecret = string.Empty;
        private string _FromSmtp = string.Empty;
        private string _ToSmtp = string.Empty;
        private string _Subject = string.Empty;
        private string _Body = string.Empty;
        private string _AttatchmentFilePath = string.Empty;



        public Form1()
        {
            InitializeComponent();

            //SendToFiddler.IsChecked = true;

            AppIdEntry.Text = "554669ca-9864-4f9e-8360-54e53bbe3f25";
            TenantIdEntry.Text = "dd55b8f6-4d6e-4cfb-8982-5d5a44d3b5ae";
            ClientSecretEntry.Text = "PnJ8Q~3mPMq5Nxk2EgF_3B8NKGwux06e_nq3QbY4";

            FromAddress.Text = "danba@dseph.onmicrosoft.com";
            ToAddress.Text = "danba@dseph.onmicrosoft.com";
            Subject.Text = "Test email message.";
            EditorBody.Text = "This is a test message from a program using the .Net Graph 4 API and using App flow oAuth.";
            AttatchmentFilePath.Text = "c:\\test\\largepicture.jpg";

        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            //_SendToFiddler = SendToFiddler.IsChecked;
            //_LogToFile = true;

            _ClientAppId = AppIdEntry.Text.Trim();
            _TenantId = TenantIdEntry.Text.Trim();
            _ClientSecret = ClientSecretEntry.Text.Trim();

            _FromSmtp = FromAddress.Text.Trim();
            _ToSmtp = ToAddress.Text.Trim();
            _Subject = Subject.Text.Trim();
            _Body = EditorBody.Text;
            _AttatchmentFilePath = AttatchmentFilePath.Text;

 


            SendEmail();
        }

        private async void SendEmail()
        {
            var tenantId = _TenantId;
            var clientId = _ClientAppId;
            var clientSecret = _ClientSecret;


            //var proxyAddress = "http://localhost:8888";


            var clientSecretCredential = new ClientSecretCredential(tenantId, clientId, clientSecret);
            // var graphClient = new GraphClientV5.GraphClientV5(clientSecretCredential);
            var graphClient = new GraphServiceClient(clientSecretCredential);

            try
            {



                // Create a draft message
                var draftMessage = new Microsoft.Graph.Models.Message
                {
                    Subject = _Body,
                    Body = new ItemBody
                    {
                        ContentType = BodyType.Text,
                        Content = _Body
                    },
                    ToRecipients = new List<Recipient>
                    {
                    new Recipient
                    {
                        EmailAddress = new EmailAddress
                        {
                            Address = _ToSmtp
                        }
                    }
                },
                    //InternetMessageHeaders = new List<InternetMessageHeader>
                    //{
                    //    new InternetMessageHeader
                    //    {
                    //        Name = "x-custom-header-group-name",
                    //        Value = "Washington",
                    //    },
                    //    new InternetMessageHeader
                    //    {
                    //        Name = "x-custom-header-group-id",
                    //        Value = "WA001",
                    //    },
                    //},
                };


                var savedDraft = await graphClient.Users[_FromSmtp].Messages.PostAsync(draftMessage);


                // var result = await graphClient.Me.MailFolders["{mailFolder-id}"].Messages.PostAsync(requestBody);

                string sName = Path.GetFileName(_AttatchmentFilePath);
                // Create an upload session
                var attachmentItem = new AttachmentItem
                {
                    AttachmentType = AttachmentType.File,
                    Name = sName,
                    Size = new FileInfo(_AttatchmentFilePath).Length
                };

                //var uploadSession = await graphClient.Me.Messages[savedDraft?.Id].Attachments
                //    .CreateUploadSession(attachmentItem)
                //    .Request()
                //    .PostAsync();

                // Below is for Users
                var uploadSessionRequestBody = new Microsoft.Graph.Users.Item.Messages.Item.Attachments.CreateUploadSession.CreateUploadSessionPostRequestBody
                {
                    AttachmentItem = attachmentItem,
                };

                // Below is for me
                //AttachmentUpload.CreateUploadSessionPostRequestBody uploadSessionRequestBody = new AttachmentUpload.CreateUploadSessionPostRequestBody
                //{
                //    AttachmentItem = attachmentItem,
                //};

                //Users[_FromSmtp]
                var uploadSession = await graphClient.Users[_FromSmtp]

                    .Messages[savedDraft?.Id]
                    .Attachments
                    .CreateUploadSession
                    .PostAsync(uploadSessionRequestBody);



                //var uploadSession = await graphClient.Me
                //    .Messages[savedDraft?.Id]
                //    .Attachments
                //    .CreateUploadSession
                //    .PostAsync(uploadSessionRequestBody);



                using var fileStream = File.OpenRead(_AttatchmentFilePath);
                var maxSliceSize = 320 * 1024; // 320 KB
                var fileUploadTask = new LargeFileUploadTask<AttachmentItem>(uploadSession, fileStream, maxSliceSize, graphClient.RequestAdapter);

                IProgress<long> progress = new Progress<long>(prog =>
                {
                    Console.WriteLine($"Uploaded {prog} bytes of {fileStream.Length} bytes");
                });

                var uploadResult = await fileUploadTask.UploadAsync(progress);

                //string s = uploadResult.ItemResponse.ContentId;

                if (uploadResult.UploadSucceeded)
                {
                    //Console.WriteLine($"Upload complete, item ID: {uploadResult.ItemResponse.}");
                    Console.WriteLine("Upload completed");

                    MessageBox.Show("Completed", "Upload completed", MessageBoxButtons.OK);
                }
                else
                {
                    Console.WriteLine("Upload failed");
                    MessageBox.Show("Error", "Upload failed", MessageBoxButtons.OK);
                }

                // Send the email
                //await graphClient.Me.Messages[savedDraft?.Id]
                //    .Send()
                //    .Request()
                //    .PostAsync();

                await graphClient.Users[_FromSmtp].Messages[savedDraft?.Id].Send.PostAsync();

                MessageBox.Show("Sent", "Message Sent", MessageBoxButtons.OK);
            }
            catch (Azure.Identity.AuthenticationFailedException ex2)
            {
                MessageBox.Show("Error AuthenticationFailedException", ex2.ToString(), MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error", ex.ToString(), MessageBoxButtons.OK);
            }


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
