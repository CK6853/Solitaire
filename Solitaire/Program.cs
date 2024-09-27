using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Solitaire
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());

            CardDeck newDeck = new CardDeck();
            newDeck.CreateFullDeck();

            
            Console.WriteLine(newDeck.ToString());
            newDeck.Shuffle();
            Console.WriteLine(newDeck.ToString());


        }
    }

    

    
}
