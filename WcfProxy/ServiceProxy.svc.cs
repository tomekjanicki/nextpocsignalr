using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using Shared;
using WcfProxy.RealTime;
using WcfProxy.Service;

namespace WcfProxy
{
    public sealed class ServiceProxy : IServiceProxy
    {
        public void PutPageFile(Stream body)
        {
            var data = ReadFully(body);
            var context = GetContextData();
            Debug.WriteLine(context.CookiesIn.Count);
            Debug.WriteLine(data.Length);
        }

        public async Task JoinPage(int page, string connectionId)
        {
            //todo handle exception from ServiceClient
            using (var client = new ServiceClient())
            {
                var data = client.ShouldSendNotification(GetContextData());
                WebOperationContextWrapper.UpdateContext(data);
                if (data.StatusCode == HttpStatusCode.OK)
                {
                    var pageId = page.ToString();
                    var context = GetHubContext();
                    await context.Groups.Add(connectionId, pageId).ConfigureAwait(false);
                }
            }
        }

        public Task LeavePage(int page, string connectionId)
        {
            //todo handle exception from ServiceClient
            using (var client = new ServiceClient())
            {
                var data = client.ShouldSendNotification(GetContextData());
                WebOperationContextWrapper.UpdateContext(data);
                if (data.StatusCode == HttpStatusCode.OK)
                {
                    var pageId = page.ToString();
                    var context = GetHubContext();
                    return context.Groups.Remove(connectionId, pageId);
                }

                return Task.FromResult(0);
            }
        }

        public void WhiteBoardV2SaveChanges(int page)
        {
            Wrap(client =>
            {
                var data = client.WhiteBoardV2SaveChanges(page, GetContextData());
                WebOperationContextWrapper.UpdateContext(data);
            });
        }

        public IEnumerable<Square> WhiteBoardV2GetSavedSquares(int page)
        {
            //todo handle exception from ServiceClient
            using (var client = new ServiceClient())
            {
                var data = client.WhiteBoardV2GetSavedSquares(page, GetContextData());
                WebOperationContextWrapper.UpdateContext(data.Data);
                return data.Squares;
            }
        }

        public IEnumerable<Square> WhiteBoardV2GetSquares(int page)
        {
            //todo handle exception from ServiceClient
            using (var client = new ServiceClient())
            {
                var data = client.WhiteBoardV2GetSquares(page, GetContextData());
                WebOperationContextWrapper.UpdateContext(data.Data);
                return data.Squares;
            }
        }

        public void WhiteBoardV2DeleteSquare(Guid id, int page)
        {
            Wrap(client =>
            {
                var data = client.WhiteBoardV2DeleteSquare(id, page, GetContextData());
                WebOperationContextWrapper.UpdateContext(data);
            });
        }

        public void WhiteBoardV2DeleteSquareWithNotification(Guid id, int page, string connectionId)
        {
            Wrap(client =>
            {
                var data = client.WhiteBoardV2DeleteSquare(id, page, GetContextData());
                WebOperationContextWrapper.UpdateContext(data);
                if (data.StatusCode == HttpStatusCode.OK)
                {
                    var context = GetHubContext();
                    context.Clients.Group(page.ToString(), connectionId).SquareDeleted(id);
                }
            });
        }

        public Guid WhiteBoardV2InsertSquare(int left, int top, int page)
        {
            //todo handle exception from ServiceClient
            using (var client = new ServiceClient())
            {
                var data = client.WhiteBoardV2InsertSquare(left, top, page, GetContextData());
                WebOperationContextWrapper.UpdateContext(data.Data);
                return data.Id;
            }
        }

        public Guid WhiteBoardV2InsertSquareWithNotification(int left, int top, int page, string connectionId)
        {
            //todo handle exception from ServiceClient
            using (var client = new ServiceClient())
            {
                var data = client.WhiteBoardV2InsertSquare(left, top, page, GetContextData());
                WebOperationContextWrapper.UpdateContext(data.Data);
                if (data.Data.StatusCode == HttpStatusCode.OK)
                {
                    var context = GetHubContext();
                    context.Clients.Group(page.ToString(), connectionId).SquareAdded(new Square { Id = data.Id, Left = left, Top = top });
                }
                return data.Id;
            }
        }

        public void WhiteBoardV2UpdateSquare(Square square, int page)
        {
            Wrap(client =>
            {
                var data = client.WhiteBoardV2UpdateSquare(square, page, GetContextData());
                WebOperationContextWrapper.UpdateContext(data);
            });
        }

        public void WhiteBoardV2UpdateSquareWithNotification(Square square, int page, string connectionId)
        {
            Wrap(client =>
            {
                var data = client.WhiteBoardV2UpdateSquare(square, page, GetContextData());
                WebOperationContextWrapper.UpdateContext(data);
                if (data.StatusCode == HttpStatusCode.OK)
                {
                    var context = GetHubContext();
                    context.Clients.Group(page.ToString(), connectionId).SquareMoved(square);
                }
            });
        }

        public IEnumerable<int> WhiteBoardV2GetPages()
        {
            //todo handle exception from ServiceClient
            using (var client = new ServiceClient())
            {
                var data = client.WhiteBoardV2GetPages(GetContextData());
                WebOperationContextWrapper.UpdateContext(data.Data);
                return data.Items;
            }
        }

        public void WhiteBoardV1AddItem(int item, int page)
        {
            Wrap(client =>
            {
                var data = client.WhiteBoardV1AddItem(item, page, GetContextData());
                WebOperationContextWrapper.UpdateContext(data);
            });
        }

        public IEnumerable<int> WhiteBoardV1GetItems(int page)
        {
            //todo handle exception from ServiceClient
            using (var client = new ServiceClient())
            {
                var data = client.WhiteBoardV1GetItems(page, GetContextData());
                WebOperationContextWrapper.UpdateContext(data.Data);
                return data.Items;
            }
        }

        public IEnumerable<int> WhiteBoardV1GetPages()
        {
            //todo handle exception from ServiceClient
            using (var client = new ServiceClient())
            {
                var data = client.WhiteBoardV1GetPages(GetContextData());
                WebOperationContextWrapper.UpdateContext(data.Data);
                return data.Items;
            }
        }

        public void Login(string userName, string password)
        {
            Wrap(client =>
            {
                var data = client.Login(userName, password, GetContextData());
                WebOperationContextWrapper.UpdateContext(data);
            });
        }

        public void Logout()
        {
            Wrap(client =>
            {
                var data = client.Logout(GetContextData());
                WebOperationContextWrapper.UpdateContext(data);
            });
        }

        private static void Wrap(Action<ServiceClient> action)
        {
            using (var client = new ServiceClient())
            {
                try
                {
                    action(client);
                }
                catch (Exception)
                {
                    WebOperationContextWrapper.UpdateContext(new WebContextData { StatusCode = HttpStatusCode.InternalServerError });
                }
            }
        }

        private static WebContextData GetContextData()
        {
            return new WebContextData
            {
                CookiesIn = WebOperationContextWrapper.GetAllCookies()
            };
        }

        private static IHubContext<IClinetV2> GetHubContext()
        {
            return GlobalHost.ConnectionManager.GetHubContext<WhiteBoardHubV2, IClinetV2>();
        }

        private static byte[] ReadFully(Stream input)
        {
            var buffer = new byte[16 * 1024];
            using (var ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }


    }
}
