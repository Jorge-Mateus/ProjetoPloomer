using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsuarioAPI.Models;

namespace UsuarioAPI.Service
{
    public class EmailService
    {
        private IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [Obsolete]
        public void EnviarEmail(string[] destinatario, string assunto, int usuarioId, string code)
        {
            Mensagem mensagem = new Mensagem(destinatario, assunto, usuarioId, code);

            var mensagemEmail = CriarCorpoEmail(mensagem);
            Enviar(mensagemEmail);

        }

        private void Enviar(MimeMessage mensagemDeEmail)
        {
            using( var client = new SmtpClient())
            {
                try
                {
                    client.Connect(_configuration.GetValue<string>("EmailSettings:SmtpServer"),_configuration.GetValue<int>("EmailSettings: Port"), true);
                    client.AuthenticationMechanisms.Remove("XOUATH2");
                    client.Authenticate(_configuration.GetValue<string>("EmailSettings: From"), _configuration.GetValue<string>("EmailSettings: Password"));
                    client.Send(mensagemDeEmail);
                }
                catch 
                {

                    throw;
                }
                finally
                {
                    client.Disconnect(true);
                    client.Dispose();

                }
            }
        }

        [Obsolete]
        private MimeMessage CriarCorpoEmail(Mensagem mensagem)
        {
            var mensagemEmail = new MimeMessage();
            mensagemEmail.From.Add(new MailboxAddress(_configuration.GetValue<string>("EmailSettings: From")));
            mensagemEmail.To.AddRange(mensagem.Destinatario);
            mensagemEmail.Subject = mensagem.Assunto;
            mensagemEmail.Body = new TextPart(MimeKit.Text.TextFormat.Text) {
                Text = mensagem.Conteudo
        };
            return mensagemEmail;
        }
    }
}
