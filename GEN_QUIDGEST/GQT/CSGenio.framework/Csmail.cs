using System;
using System.Collections.Generic;
using System.IO;
using MimeKit;
using MailKit.Net.Smtp;
using System.Text.RegularExpressions;
using MimeKit.Utils;

namespace CSGenio.framework
{
    /// <summary>
    /// Classe que representa um email
    /// exists a posiblidade de enviar vários ficheros em attachment, basta passar um array de string com os nomes dos ficheiros a anexar. atenção que os nomes dos ficheiros tem que ser caminhos completos.    
    /// também e possível enviar um mail to vários destinatários, basta criar uma string com os mail separados por vírgula (,)ex:"quidgest@quidgest.pt,jpedro@quidgest.pt"    
    /// </summary>
    public class CSmail
    {
        private string de;//e-mail do remetente
        private string to;//e-mail(s) do destinatário(s)
        private string subject;//subject do e-mail
        private string body;//body do e_email
        private bool bodyhtml;//indica se o body do e-mail vai em html //(FFS 2014.10.16)
        private string[] attachment;//lista com os nomes dos ficheiros anexos
        private string smtpServer; // GenioServer de mail 
        private bool ssl = false; // Ligação ssl (MA 2009.10.07)
        private int port = 25; // porta smtp (MA 2009.10.07)
        private bool auth = false;
        private string user;
        private string pass;
        private string cc; //endereços em CC (JMT 2011.04.04)
        private string bcc; //endereços em Bcc (PR 2014.10.16)
        private string textass; //text após imagem da assinatura (SF 2016.02.10)
        private string pathimg; //imagem da assinatura (SF 2016.02.10)
        private string nomeremetente; //nome a apresentar no remetente
        private Dictionary<string, Stream> dictionaryanexos; //Anexos por stream (ao invés de path)
        private List<Stream> streamimagens; //Imagens no corpo do email, por stream (ao invés de path)
        public string ReplyTo { get; set; } // Propriedade para o endereço "Reply-To"

        /// <summary>
        /// Constructor dum Qfield que nao é formula, nem array,  nem tem Qvalue default
        /// </summary>
        /// <param name="de"></param>
        /// <param name="para"></param>
        /// <param name="assunto"></param>
        /// <param name="anexo"></param>
        /// <param name="smtpServer"></param>
        public CSmail(string de,
                         string to,
                         string subject,
                         string body,
                         string[] attachment,
                         string smtpServer,
                         int port, // (MA 2009.10.07)
                         bool ssl,  // (MA 2009.10.07)
                         string cc,  // (JMT 2011.04.04)
                         string bcc,
                         string textass,
                         string pathimg,
                         bool bodyhtml//(FFS 2014.10.16)
        )
        {
            this.de = de;
            this.to = to;
            this.subject = subject;
            this.body = body;
            this.bodyhtml = bodyhtml;//(FFS 2014.10.16)
            this.attachment = attachment;
            this.smtpServer = smtpServer;
            this.port = port; // (MA 2009.10.07)
            this.ssl = ssl; // (MA 2009.10.07)
            this.cc = cc;   // (JMT 2011.04.04)
            this.bcc = bcc;
            this.textass = textass;
            this.pathimg = pathimg;
        }
		
		public CSmail(string de,
                         string to,
                         string subject,
                         string body,
                         string[] attachment,
                         string smtpServer,
                         int port, // (MA 2009.10.07)
                         bool ssl,  // (MA 2009.10.07)
                         string cc  // (JMT 2011.04.04)
        )
        {
            this.de = de;
            this.to = to;
            this.subject = subject;
            this.body = body;
            this.bodyhtml = false;//(FFS 2014.10.16)
            this.attachment = attachment;
            this.smtpServer = smtpServer;
            this.port = port; // (MA 2009.10.07)
            this.ssl = ssl; // (MA 2009.10.07)
            this.cc = cc;   // (JMT 2011.04.04)
            this.bcc = "";
            this.textass = "";
            this.pathimg = "";
        }
        public CSmail(string de,
                         string para,
                         string assunto,
                         string corpo,
                         string[] anexo,
                         string smtpServer,
                         int port, // (MA 2009.10.07)
                         bool ssl,  // (MA 2009.10.07)
                         string cc,  // (JMT 2011.04.04)
                         string nomeremetente
        )
        {
            this.de = de;
            this.to = para;
            this.subject = assunto;
            this.body = corpo;
            this.bodyhtml = false;//(FFS 2014.10.16)
            this.attachment = anexo;
            this.smtpServer = smtpServer;
            this.port = port; // (MA 2009.10.07)
            this.ssl = ssl; // (MA 2009.10.07)
            this.cc = cc;   // (JMT 2011.04.04)
            this.bcc = "";
            this.textass = "";
            this.pathimg = "";
            this.nomeremetente = nomeremetente;
        }

        public CSmail(   string nomeremetente,
                         string de,
                         string para,
                         string assunto,
                         string corpo,
                         Dictionary<string, Stream> dictionaryanexos, //nome_anexo + anexo
                         string smtpServer,
                         int port, // (MA 2009.10.07)
                         bool ssl,  // (MA 2009.10.07)
                         string cc,  // (JMT 2011.04.04)
                         string bcc,
                         List<Stream> imagens,
                         string textass,
                         bool bodyhtml
                         //(FFS 2014.10.16)
        )
        {
            this.nomeremetente = nomeremetente;
            this.de = de;
            this.to = para;
            this.subject = assunto;
            this.body = corpo;
            this.dictionaryanexos = dictionaryanexos;
            this.smtpServer = smtpServer;
            this.port = port; // (MA 2009.10.07)
            this.ssl = ssl; // (MA 2009.10.07)
            this.cc = cc;   // (JMT 2011.04.04)
            this.bcc = bcc;
            this.streamimagens = imagens;
            this.textass = textass;
            this.bodyhtml = bodyhtml;
        }

        /// <summary>
        /// Constructor dum Qfield que nao é formula, nem array,  nem tem Qvalue default
        /// </summary>
        public CSmail()
        {
            de = "quidgest@quidgest.pt";
            to = "quidmail@quidgest.pt";
            subject = "";
            body = "E-mail enviado pelo programa RQW";
            bodyhtml = false;//(FFS 2014.10.16)
            attachment = new string[1] { "" };
            smtpServer = "cp99.webserver.pt";
            port = 25;  // (MA 2009.10.07)
            ssl = false; // (MA 2009.10.07)
            cc = "";    //(JMT 2011.04.04)
            bcc = ""; //(PR 2012.04.03)
            textass = "";//(SF 2016.02.10)
            pathimg = "";//(SF 2012.02.10)
        }


			
        /// <summary>
        /// Método que envia o email
        /// </summary>        
        public bool Send()
        {
            if (validate())
            {
                // To turn on 1.2 without affecting other protocols. It is preferred that it be configured at application startup.
                System.Net.ServicePointManager.SecurityProtocol |= System.Net.SecurityProtocolType.Tls12;
				
                using MimeMessage msg = new();
                msg.From.Add(new MailboxAddress(nomeremetente, de));

                AddValidEmails(to, msg.To);
                AddValidEmails(ReplyTo, msg.ReplyTo);
                AddValidEmails(cc, msg.Cc);
                AddValidEmails(bcc, msg.Bcc);

                msg.Subject = subject;

                var bodyBuilder = new BodyBuilder
                {
                    HtmlBody = bodyhtml ? body : null,
                    TextBody = bodyhtml ? null : body
                };

                // Acrecentar imagem da assinatura no body do email
                if (!string.IsNullOrEmpty(pathimg) && File.Exists(pathimg))
                {
                    var image = bodyBuilder.LinkedResources.Add(pathimg);
                    image.ContentId = MimeUtils.GenerateMessageId();
                    bodyBuilder.HtmlBody ??= string.Empty;
                    bodyBuilder.HtmlBody += $"<img src=\"cid:{image.ContentId}\">{textass}";
                }
                else if(streamimagens?.Count > 0)
                {
                    bodyBuilder.HtmlBody ??= string.Empty;
                    foreach (var imageStream in streamimagens)
                    {
                        var linkedResource = new MimePart(new ContentType("application", "octet-stream"))
                        {
                            ContentId = MimeUtils.GenerateMessageId(),
                            ContentTransferEncoding = ContentEncoding.Base64,
                            Content = new MimeContent(imageStream),
                            ContentDisposition = new ContentDisposition(ContentDisposition.Inline)
                        };
                        bodyBuilder.LinkedResources.Add(linkedResource);
                        bodyBuilder.HtmlBody += $"<br/><img src=\"cid:{linkedResource.ContentId}\"/>";
                    }
                    bodyBuilder.HtmlBody += $"<br/>{textass}";
                    bodyBuilder.HtmlBody = bodyBuilder.HtmlBody.Replace(Environment.NewLine, "<br/>");
                }
                else
                    bodyBuilder.TextBody += textass;

                // Linked resources
                LinkedResources?.ForEach(linkedResource => bodyBuilder.LinkedResources.Add(linkedResource.Resource));


                // Attachments (string[])
                if (attachment != null)
                {
                    foreach (var attachmentFile in attachment)
                    {
                        if (!string.IsNullOrEmpty(attachmentFile) && File.Exists(attachmentFile))
                        {
                            bodyBuilder.Attachments.Add(attachmentFile);
                        }
                    }
                }

                // Attachments (Dictionary<string, stream>)
                if(dictionaryanexos != null)
                {
                    foreach (var attachmentFile in dictionaryanexos)
                    {
                        bodyBuilder.Attachments.Add(attachmentFile.Key, attachmentFile.Value);
                    }
                }

                msg.Body = bodyBuilder.ToMessageBody();

                using SmtpClient client = new();
                client.Connect(smtpServer, port); // SSL or Auto ?

                if (auth)
                {
                    client.Authenticate(user, pass);
                }

                client.Send(msg);
                client.Disconnect(true);
				
                return true;
            }
            else
            {
                return false;
            }
        }

        private void AddValidEmails(string addresses, InternetAddressList mailAddressList)
        {
            if (string.IsNullOrEmpty(addresses))
                return;

            foreach (string address in addresses.Split(new char[] { ';', ',' }))
            {
                if (validateMail(address))
                {
                    mailAddressList.Add(new MailboxAddress(null, address));
                }
            }
        }

        /// <summary>
        /// Método que dado um array de strings preenche os destinatario ( DQ - 14072006)
        /// </summary>
        /// <param name="destin"></param>
        public void fillRecipient(object[] destin)
        {
            this.to = "";
            for (int i = 0; i < destin.Length; i++)
            {
                if (validateMail(destin[i].ToString()))
                    this.to += destin[i].ToString() + ",";
            }
            this.to = this.to.Remove(this.to.LastIndexOf(","));
        }

        /// <summary>
        /// English Version - Fills multiple mail destination addresses
        /// </summary>
        /// <param name="destin"></param>
        public void fillDestinations(object[] destin)
        {
            fillRecipient(destin);
        }

        /// <summary>
        /// Método que verifica se o email é válido.
        /// </summary>
        /// <param name="inputEmail"></param>
        public static bool validateMail(string inputEmail)
        {
            string strRegex = @"^[a-zA-Z0-9_+&*-]+(?>\.[a-zA-Z0-9_+&*-]+)*@(?>[a-zA-Z0-9-]+\.)+[a-zA-Z]{2,7}$";
            Regex re = new Regex(strRegex, RegexOptions.IgnoreCase, TimeSpan.FromSeconds(1));
            if (re.IsMatch(inputEmail))
                return (true);
            else
                return (false);
        }

        /// <summary>
        /// Método que faz as validações dos parâmetros do email são válidos.
        /// </summary>
        public bool validate()
        {
            if (validateMail(de))
            {
                if (smtpServer.Equals(""))
                    return false;

            }
            else
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Adds the provided linked resource to the email's linked resources collection.
        /// This method is used when you already have an instance of a linked resource and want to add 
        /// it to the collection of resources that will be referenced in the HTML body of the email.
        /// </summary>
        /// <param name="linkedResource">The linked resource to be added, which contains an image or other media to be embedded in the email.</param>
        /// <returns>Returns the same linked resource that was added to the collection.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the provided linked resource is null.</exception>
        public CSMail.EmailLinkedResource AddHtmlImgLink(CSMail.EmailLinkedResource linkedResource)
        {
            // Validate that the linked resource is not null
            if (linkedResource == null)
                throw new ArgumentNullException(nameof(linkedResource), "Linked resource cannot be null.");

            LinkedResources.Add(linkedResource);

            // Return the linked resource for potential chaining or reference
            return linkedResource;
        }

        /// <summary>
        /// Adds an HTML image link (a linked resource) using the image file at the specified path.
        /// This method creates a linked resource from a file path and associates it with a Content ID, 
        /// allowing the image to be referenced in the HTML body of the email.
        /// </summary>
        /// <param name="contentId">The Content ID for referencing the image in the email body.</param>
        /// <param name="filePath">The full path to the image file to be embedded.</param>
        /// <returns>Returns the created linked resource associated with the image.</returns>
        public CSMail.EmailLinkedResource AddHtmlImgLink(string contentId, string filePath)
        {
            // Create a new EmailLinkedResource object using the file path and content ID
            var linkedResource = new CSMail.EmailLinkedResource(filePath, contentId);
            return AddHtmlImgLink(linkedResource);
        }

        /// <summary>
        /// Adds an HTML image link (a linked resource) using the provided byte array representing the image data.
        /// This method creates a linked resource from a byte array and associates it with a Content ID, 
        /// allowing the image to be referenced in the HTML body of the email.
        /// </summary>
        /// <param name="contentId">The Content ID for referencing the image in the email body.</param>
        /// <param name="fileData">The byte array containing the image data to be embedded.</param>
        /// <param name="mimeType">The MIME type of the image (e.g., "image/jpeg", "image/png").</param>
        /// <returns>Returns the created linked resource associated with the image.</returns>
        public CSMail.EmailLinkedResource AddHtmlImgLink(string contentId, byte[] fileData, ContentType mimeType)
        {
            // Create a new EmailLinkedResource object using the byte array, content ID, and MIME type
            var linkedResource = new CSMail.EmailLinkedResource(fileData, contentId, mimeType);
            return AddHtmlImgLink(linkedResource);
        }

        /// <summary>
        /// Adds an HTML image link (a linked resource) using the provided stream containing the image data.
        /// This method creates a linked resource from a stream and associates it with a Content ID, 
        /// allowing the image to be referenced in the HTML body of the email.
        /// </summary>
        /// <param name="contentId">The Content ID for referencing the image in the email body.</param>
        /// <param name="fileStream">The stream containing the image data to be embedded.</param>
        /// <param name="mimeType">The MIME type of the image (e.g., "image/jpeg", "image/png").</param>
        /// <returns>Returns the created linked resource associated with the image.</returns>
        public CSMail.EmailLinkedResource AddHtmlImgLink(string contentId, Stream fileStream, ContentType mimeType)
        {
            // Create a new EmailLinkedResource object using the stream, content ID, and MIME type
            var linkedResource = new CSMail.EmailLinkedResource(fileStream, contentId, mimeType);
            return AddHtmlImgLink(linkedResource);
        }

        /// <summary>
        /// Método que devolve ou coloca o remetente da mensagem
        /// </summary>
        public string From
        {
            get { return de; }
            set { de = value; }
        }


        /// <summary>
        /// Método que devolve ou coloca o(s) destinatários da mensagem
        /// </summary>
        public string To
        {
            get { return to; }
            set { to = value; }
        }


        /// <summary>
        /// Método que devolve ou coloca o subject da mensagem
        /// </summary>          
        public string Subject
        {
            get { return subject; }
            set { subject = value; }
        }


        /// <summary>
        /// Método que devolve ou coloca o body da mensagem
        /// </summary>
        public string Body
        {
            get { return body; }
            set { body = value; }
        }


        /// <summary>
        /// Método que devolve e coloca a lista de ficheiros anexos
        /// </summary>
        public string[] Attachment
        {
            get { return attachment; }
            set { attachment = value; }
        }

        /// <summary>
        /// Método que devolve e coloca o servidor smtp
        /// </summary>
        public string SmtpServer
        {
            get { return smtpServer; }
            set { smtpServer = value; }
        }

        /// <summary>
        /// Método que define se a ligação é ssl - (MA 2009.10.07)
        /// </summary>
        public bool SSL
        {
            get { return ssl; }
            set { ssl = value; }
        }

        /// <summary>
        /// Método que define a porta smtp - (MA 2009.10.07)
        /// </summary>
        public int Port
        {
            get { return port; }
            set { port = value; }
        }

        /// <summary>
        /// Método que define se a ligação deve ser autenticada - (MA 2009.10.07)
        /// </summary>
        public bool Auth
        {
            get { return auth; }
            set { auth = value; }
        }
        /// <summary>
        /// Método que devolve e coloca o servidor smtp
        /// </summary>
        public string User
        {
            get { return user; }
            set { user = value; }
        }
        /// <summary>
        /// Método que devolve e coloca o servidor smtp
        /// </summary>
        public string Pass
        {
            get { return pass; }
            set { pass = value; }
        }

        /// <summary>
        /// Método que devolve e coloca os endereços em CC - (JMT 2011.04.04)
        /// </summary>
        public string CC
        {
            get { return cc; }
            set { cc = value; }
        }

        /// <summary>
        /// Método que devolve e coloca o body do e-mail em html - (FFS 2014.10.16)
        /// </summary>
        public bool BodyHtml
        {
            get { return bodyhtml; }
            set { bodyhtml = value; }
        }

        /// <summary>
        /// Método que devolve e coloca os endereços em Bcc - (PR 2012.10.16)
        /// </summary>
        public string Bcc
        {
            get { return bcc; }
            set { bcc = value; }
        }

        /// <summary>
        /// Método que devolve e coloca a pasta da imagem to a assinatura - (SF 2016.02.10)
        /// </summary>
        public string Pathimg
        {
            get { return pathimg; }
            set { pathimg = value; }
        }
        
        /// <summary>
        /// Método que devolve e coloca o text após a imagem da assinatura - (SF 2016.02.10)
        /// </summary>
        public string Textass
        {
            get { return textass; }
            set { textass = value; }
        }

        /// <summary>
        /// Método que devolve e coloca o nome do remetente a apresentar no email
        /// </summary>
        public string NomeRemetente
        {
            get { return nomeremetente; }
            set { nomeremetente = value; }
        }

        /// <summary>
        /// Método que devolve e preenche a lista de imagens a adicionar ao corpo do email
        /// </summary>
        public List<Stream> StreamImagens
        {
            get { return streamimagens; }
            set { streamimagens = value; }
        }

        /// <summary>
        /// Método que devolve e preenche o dicionário de dados com os anexos a adicionar ao email
        /// </summary>
        public Dictionary<string, Stream> DictionaryAnexos
        {
            get { return dictionaryanexos; }
            set { dictionaryanexos = value; }
        }


        /// <summary>
        /// A collection of linked resources, such as embedded images, used in the HTML body of the email.
        /// Each linked resource is represented by an instance of the EmailLinkedResource class, 
        /// and can be referenced in the email content via a Content ID.
        /// </summary>
        public List<CSMail.EmailLinkedResource> LinkedResources { get; private set; } = [];
    }

    namespace CSMail
    {
        /// <summary>
        /// This class is responsible for managing linked resources (such as embedded images) 
        /// that are used in email bodies. It supports loading images from file paths, streams, 
        /// or byte arrays and associates them with a Content ID, allowing reference in the email content.
        /// </summary>
        public class EmailLinkedResource
        {
            /// <summary>
            /// The Content ID used to reference the resource in the email body. 
            /// If the resource is null, it returns null.
            /// </summary>
            public string ContentId { get { return Resource?.ContentId; } }

            /// <summary>
            /// The linked resource representing the image.
            /// This is a MimePart object that encapsulates the content of the resource.
            /// </summary>
            public MimePart Resource { get; private set; }

            /// <summary>
            /// Creates a linked resource from a file path.
            /// This constructor loads the file, determines its MIME type based on the file extension,
            /// and sets up the linked resource to be embedded in the email body.
            /// </summary>
            /// <param name="filePath">The full path to the image file.</param>
            /// <param name="contentId">The Content ID for referencing this image in the email body.</param>
            /// <exception cref="ArgumentNullException">Thrown when the file path is null or empty.</exception>
            /// <exception cref="FileNotFoundException">Thrown when the specified file is not found.</exception>
            public EmailLinkedResource(string filePath, string contentId)
            {
                if (string.IsNullOrEmpty(filePath))
                    throw new ArgumentNullException(nameof(filePath), "File path cannot be null or empty.");

                if (!File.Exists(filePath))
                    throw new FileNotFoundException("File not found.", filePath);

                var fileName = Path.GetFileName(filePath);
                // Determines the MIME type of the image based on its file extension.
                var mimeType = GetMimeType(filePath);
                // Load the file content as a byte array and convert it to a memory stream.
                var fileData = File.ReadAllBytes(filePath);
                var fileStream = new MemoryStream(fileData);

                // Set the linked resource using the file stream, content ID, MIME type, and file name.
                SetResource(fileStream, contentId, mimeType, fileName);
            }

            /// <summary>
            /// Creates a linked resource from a byte array.
            /// This constructor is useful when you already have the image data in memory 
            /// as a byte array and want to embed it in an email.
            /// </summary>
            /// <param name="imageBytes">The byte array representing the file data.</param>
            /// <param name="contentId">The Content ID for referencing this image in the email body.</param>
            /// <param name="mimeType">The MIME type of the linked resource (e.g., "image/jpeg").</param>
            /// <exception cref="ArgumentNullException">Thrown when the byte array is null or empty.</exception>
            public EmailLinkedResource(byte[] imageBytes, string contentId, ContentType mimeType)
            {
                if (imageBytes == null || imageBytes.Length == 0)
                    throw new ArgumentNullException(nameof(imageBytes), "Image data cannot be null or empty.");

                var fileStream = new MemoryStream(imageBytes);

                // Set the linked resource using the byte stream, content ID, and MIME type.
                SetResource(fileStream, contentId, mimeType);
            }

            /// <summary>
            /// Creates a linked resource from a stream.
            /// This constructor is useful when you want to stream the image data directly 
            /// from a source without fully loading it into memory.
            /// </summary>
            /// <param name="imageStream">The stream containing the image data.</param>
            /// <param name="contentId">The Content ID for referencing this image in the email body.</param>
            /// <param name="mimeType">The MIME type of the linked resource (e.g., "image/png").</param>
            /// <exception cref="ArgumentNullException">Thrown when the image stream is null.</exception>
            public EmailLinkedResource(Stream imageStream, string contentId, ContentType mimeType)
            {
                if (imageStream == null)
                    throw new ArgumentNullException(nameof(imageStream), "Image stream cannot be null.");

                // Set the linked resource using the provided stream, content ID, and MIME type.
                SetResource(imageStream, contentId, mimeType);
            }

            /// <summary>
            /// Helper method to set the linked resource properties, which includes 
            /// creating a MimePart object with appropriate content, content type, 
            /// content disposition, and content transfer encoding.
            /// </summary>
            /// <param name="fileStream">The stream containing the image data.</param>
            /// <param name="contentId">The content identifier used to reference the image in the email body.</param>
            /// <param name="mimeType">The MIME type of the image (defaults to "application/octet-stream" if not provided).</param>
            /// <param name="fileName">The file name of the image (defaults to an empty string if not provided).</param>
            /// <returns>Returns the created MimePart representing the linked resource.</returns>
            public MimePart SetResource(Stream fileStream, string contentId = null, ContentType mimeType = null, string fileName = null)
            {
                // If no MIME type is provided, default to "application/octet-stream".
                mimeType ??= new ContentType("application", "octet-stream");
                fileName ??= string.Empty;

                // Create a new MimePart for the resource with the appropriate properties.
                Resource = new MimePart(mimeType)
                {
                    ContentId = contentId ?? MimeUtils.GenerateMessageId(), // Generate a content ID if not provided.
                    ContentTransferEncoding = ContentEncoding.Base64, // Use base64 encoding for the resource.
                    Content = new MimeContent(fileStream), // Attach the file stream as the resource content.
                    ContentDisposition = new ContentDisposition(ContentDisposition.Inline), // Set content disposition as inline.
                    FileName = fileName, // Set the file name for the resource.
                    ContentLocation = new Uri(fileName, UriKind.Relative) // Set content location for reference.
                };

                // Ensure that the content type includes the file name.
                Resource.ContentType.Name = fileName;

                return Resource;
            }

            /// <summary>
            /// Helper method to determine the MIME type based on the file extension.
            /// Uses the MimeKit library's GetMimeType method to map file extensions to MIME types.
            /// </summary>
            /// <param name="fileName">The file name or path to determine the MIME type for.</param>
            /// <returns>Returns the corresponding MIME type as a ContentType object.</returns>
            public static ContentType GetMimeType(string fileName)
            {
                // Use MimeTypes class from MimeKit to determine the correct MIME type.
                var mimeType = MimeTypes.GetMimeType(fileName);

                // Parse the MIME type into a ContentType object.
                return ContentType.Parse(mimeType);
            }
        }
    }
}