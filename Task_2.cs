using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    class Program
    {
        static void Main(string[] args)
        {
            int i =0;
            Console.OutputEncoding = Encoding.UTF8;
            Regex Filter = new Regex("[A-Za-zА-Яа-я'ЁёЙйé]+", RegexOptions.Compiled);
            List<string> Words = new List<string>();
            string[] text = File.ReadAllLines("/*ПУТЬ К ФАЙЛУ*/", Encoding.GetEncoding(1251));
            int[] nums = new int[0]; 

            //ПОИСК УНИКАЛЬНЫХ СЛОВ
            foreach (string line in text)
            {
                foreach (Match m in Filter.Matches(line))
                {
                    string word = m.Value;
                    word = word.ToLower();
                    if (!Words.Contains(word)) //Добавление новых слов в список
                    {
                        Words.Add(word);
                        Array.Resize(ref nums, nums.Length + 1);
                        nums[i] = 1;
                        i++;
                    }
                    else // Если слово есть в списке, увеличить количество вхождений на 1
                    {
                        int index = Words.FindIndex(x => x == word);
                        nums[index] += 1;
                    }
                }   
            }
            //СОРТИРОВКА ПО УБЫВАНИЮ
             int temp;
             string temp2;
              for (i = 0; i < nums.Length - 1; i++)
              {
                  for (int j = i + 1; j < nums.Length; j++)
                  {
                      if (nums[i] < nums[j])
                      {
                         temp2 = Words[i];
                         temp = nums[i];
                         Words[i] = Words[j];
                         nums[i] = nums[j];
                         Words[j] = temp2;
                         nums[j] = temp;
                      }
                  }
              }
            
           //ВЫВОД В КОНСОЛЬ
           /*
            i = 0;
            foreach (var item in Words)
            {
                Console.WriteLine($"{item} {nums[i]}");
                i++;
            }
            */

            //ВЫВОД В ФАЙЛ
            string[] array3 = new string[Words.Count];
            for (int j = 0; j < Words.Count; j++)
            {
                array3[j] = Words[j]+ "        " + nums[j];
            }
            File.WriteAllLines("result.txt", array3);
            Console.ReadLine();
        }
    }
}
