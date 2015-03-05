using System;
using System.Linq;
using System.Text;
using ClarionSharp;
using ClarionSharp.Bindings;

namespace Clarion.Example
{
    class Program
    {
        static void Main()
        {
            const string filePath = "ANSW1.DAT";

            var bindingMap = new ClarionBindingMap<AnswersData>()
                .Map("NUM_REG", x => x.NumReg)
                .Map("NUM_TEST", x => x.NumTest)
                .Map("QUEST", x => x.QuestionCount)
                .Map("NUM_Q", x => x.Numbers)
                .Map("ANSWER", x => x.Answers)
                ;
            using (var file = new ClarionDatabase(filePath, Encoding.ASCII))
            {
                var results = file.ReadAllRecords(bindingMap);
                var result = results.First();
                Console.WriteLine("NUM_REG: {0} ", result.NumReg);
                Console.WriteLine("NUM_TEST: {0} ", result.NumTest);
                Console.WriteLine("QUEST: {0} ", result.QuestionCount);
                Console.WriteLine("NUM_Q: {0} ", string.Join(",", result.Numbers));
                Console.WriteLine("ANSWER: {0} ", string.Join(",", result.Answers));
            }
            Console.ReadLine();
        }
    }
}
