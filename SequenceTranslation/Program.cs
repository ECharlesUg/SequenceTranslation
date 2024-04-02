class Program
{
    static void Main(string[] args)
    {
        // these values define the protien with the most repitions and its value
        int maxRep = 0;
        string maxProtein = "";

        // this connects the txt file so it can be read and analyzed
        string sequence = @"C:\Users\Admin\source\repos\SequenceTranslation\SequenceTranslation\RNA.txt";

        // this dictionary defines the key-value pairs of the letters and their corresponding protein
        Dictionary<string, string> table = new Dictionary<string, string>()
        {
            {"UGG", "Tryptophan"},
            {"UCU", "Serine"}, {"UCC", "Serine"}, {"UCA", "Serine"}, {"UCG", "Serine"},
            {"UAU", "Tyrosine"}, {"UAC", "Tyrosine"},
            {"UGU", "Cysteine"}, {"UGC", "Cysteine"},
            {"AUG", "Methionine"},
            {"UUU", "Phenylalanine"}, {"UUC", "Phenylalanine"},
            {"UUA", "Leucine"}, {"UUG", "Leucine"},
        };

        try
        {
            // this is to store the repitions of each protein value
            Dictionary<string, int> storeCount = new Dictionary<string, int>();
            foreach (string value in table.Values)
            {
                storeCount[value] = 0;
            }
            using (StreamReader read = File.OpenText(sequence))
            {
                string rna;

                // reads the txt file
                while ((rna = read.ReadLine()) != null)
                {

                    for (int i = 0; i < rna.Length - 3; i += 3)
                    {
                        // splits text from txt file into pairs of three lettered strings
                        string codon = rna.Substring(i, Math.Min(3, rna.Length - i));

                        // checks to see if string value is in dictionary
                        if (table.ContainsKey(codon))
                        {
                            // redefines string to connected value pair found in dictionary every loop
                            string word = table[codon];

                            // counts repition of different same keys throughout the loop 
                            storeCount[word]++;
                        }
                        // stops loop/stops program from running 
                        // because stop value key is encountered as it is not in the dictionary
                        else { break; }
                    }
                }
            }

            Console.WriteLine("Protein Occurrences:");
            foreach (var num in storeCount)
            {
                // prints key value pairs holding a value more than 0
                if (num.Value > 0)
                {
                    Console.WriteLine($"{num.Key}: {num.Value}");
                }

                // prints the protein with most repitions and its value
                if (num.Value > maxRep)
                {
                    maxRep = num.Value;
                    maxProtein = num.Key;
                }
            }
            Console.WriteLine($"Protein '{maxProtein}' has the most occurence with {maxRep} repititions in the RNA sequence ");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine($"File not found");
        }
        catch (IOException)
        {
            Console.WriteLine($"An I/O error occurred");
        }
        catch (Exception)
        {
            Console.WriteLine($"unexpected error occurred");
        }
    }
}
