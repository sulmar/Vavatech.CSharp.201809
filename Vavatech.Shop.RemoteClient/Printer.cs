using System;
using System.Collections.Generic;
using System.Text;

namespace Vavatech.Shop.RemoteClient
{
    public class Printer : IDisposable
    {
        private void Init()
        {
            // ladujemy zasoby
        }

        public void Print(string input)
        {
            Console.WriteLine($"printing {input}");

            throw new ApplicationException("Testowy");
        }

        public void Release()
        {
            // zwalniamy zasoby

            Console.WriteLine("zwalniamy zasoby");
        }

        public void Dispose()
        {
            Release();
        }
    }
}
