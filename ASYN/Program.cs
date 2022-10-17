using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ASYN
{
    class Program
    {
        static void Main(string[] args)
        {

            bool boolResult = false;
            Task.Run(async () =>
            {
                Barman barman_ = new Barman();
                Task<bool> return1 = barman_.CalientaSnack();
                barman_.HacerCoctel();

                boolResult = await return1;

            }).GetAwaiter().GetResult();

            if (boolResult) {
                Console.WriteLine("el proceso termino correctamente.");
            }

        }


        public class Barman
        {
            public async Task<bool> CalientaSnack()
            {
                Console.WriteLine("mete el snack al horno");
                HttpClient cliente = new HttpClient();
                await cliente.GetAsync("http://hdeleon.net");
                Console.WriteLine("Saca el snack del horno");
                return true;
            }

            public async Task HacerCoctel()
            {
                Console.WriteLine("comienza a hacer el coctel");
                Thread.Sleep(3000);
                Console.WriteLine("termina de hacer el coctel.");
                Thread.Sleep(1000);
            }


        }

    }
}
