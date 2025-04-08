class Program
{
    /****************************************************
   * nazwa funkcji: Algorytm
   * typ zwracany: int, zwraca indeks równowagi
   * informacje: Algorytm wyszukujacy indeks równowagi w tablicy
   * autor: danyPL
   **************************************************** 
   */
    static int Algorytm(List<int> nums)
    {

        int n = nums.Count;
        int left, right;

        for (int i = 0; i < n; i++)
        {
            left = 0;
            for (int j = 0; j < i; j++)
            {
                left += nums[j];
            }
            right = 0;
            for (int j = i + 1; j < n; j++)
            {
                right += nums[j];
            }
            if (left == right)
            {
                return i;
            }
        }
        return -1;
    }
    /****************************************************
     * nazwa funkcji: Main
     * typ zwracany: Void, nic nie zwraca
     * informacje: funckja inicjalizująca działanie aplikacji
     * autor: danyPL
     **************************************************** 
     */
    static void Main(string[] args)
    {
        string[] nums = Console.ReadLine().Split(",");
        List<int> Cnums = new();
        foreach(string num in nums)
        {
            Cnums.Add(Convert.ToInt32(num));
        }
        int wynik = Algorytm(Cnums);
        Console.WriteLine($"Znaleziono indeks równowagi {wynik}");

    }

}