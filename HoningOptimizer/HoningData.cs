using System.Collections.Generic;

namespace HoningOptimizer
{
    public class HoningData
    {
        public HoningData()
        {
            chances.Add(7, 0.6);
            chances.Add(8, 0.45);
            chances.Add(9, 0.3);
            chances.Add(10, 0.3);
            chances.Add(11, 0.3);
            chances.Add(12, 0.15);
            chances.Add(13, 0.15);
            chances.Add(14, 0.15);
            chances.Add(15, 0.1);
            
            weaponcosts.Add(7, new List<int>() {258,8,4});
            weaponcosts.Add(8, new List<int>() {258,8,4});
            weaponcosts.Add(9, new List<int>() {258,8,4});
            weaponcosts.Add(10, new List<int>() {320,10,4});
            weaponcosts.Add(11, new List<int>() {320,10,4});
            weaponcosts.Add(12, new List<int>() {320,10,4});
            weaponcosts.Add(13, new List<int>() {380,10,6});
            weaponcosts.Add(14, new List<int>() {380,12,6});
            weaponcosts.Add(15, new List<int>() {380,12,6});
            
            armorcosts.Add(7, new List<int>() {156,4,2});
            armorcosts.Add(8, new List<int>() {156,4,2});
            armorcosts.Add(9, new List<int>() {156,4,2});
            armorcosts.Add(10, new List<int>() {192,6,4});
            armorcosts.Add(11, new List<int>() {192,6,4});
            armorcosts.Add(12, new List<int>() {192,6,4});
            armorcosts.Add(13, new List<int>() {228,6,4});
            armorcosts.Add(14, new List<int>() {228,8,4});
            armorcosts.Add(15, new List<int>() {228,8,4});
            
            grace.Add(7, new Solar(0.0125, 12));
            grace.Add(8, new Solar(0.0125, 12));
            grace.Add(9, new Solar(0.0125, 12));
            grace.Add(10, new Solar(0.0084, 12));
            grace.Add(11, new Solar(0.0021, 24));
            grace.Add(12, new Solar(0.0021, 24));
            grace.Add(13, new Solar(0.0021, 24));
            grace.Add(14, new Solar(0.0021, 24));
            grace.Add(15, new Solar(0.0021, 24));
            
            blessing.Add(7, new Solar(0.025, 6));
            blessing.Add(8, new Solar(0.025, 6));
            blessing.Add(9, new Solar(0.025, 6));
            blessing.Add(10, new Solar(0.0176, 6));
            blessing.Add(11, new Solar(0.0042, 12));
            blessing.Add(12, new Solar(0.0042, 12));
            blessing.Add(13, new Solar(0.0042, 12));
            blessing.Add(14, new Solar(0.0042, 12));
            blessing.Add(15, new Solar(0.0042, 12));
            
            protection.Add(7, new Solar(0.075, 2));
            protection.Add(8, new Solar(0.075, 2));
            protection.Add(9, new Solar(0.075, 2));
            protection.Add(10, new Solar(0.05, 2));
            protection.Add(11, new Solar(0.0125, 4));
            protection.Add(12, new Solar(0.0125, 4));
            protection.Add(13, new Solar(0.0125, 4));
            protection.Add(14, new Solar(0.0125, 4));
            protection.Add(15, new Solar(0.0125, 4));
            
            pity.Add(7, 5);
            pity.Add(8, 6);
            pity.Add(9, 7);
            pity.Add(10, 7);
            pity.Add(11, 7);
            pity.Add(12, 11);
            pity.Add(13, 11);
            pity.Add(14, 11);
            pity.Add(15, 15);
        }
        
        public Dictionary<int, double> chances = new Dictionary<int, double>();
        public Dictionary<int, List<int>> weaponcosts = new Dictionary<int, List<int>>();
        public Dictionary<int, List<int>> armorcosts = new Dictionary<int, List<int>>();

        public Dictionary<int, Solar> grace = new Dictionary<int, Solar>();
        public Dictionary<int, Solar> blessing = new Dictionary<int, Solar>();
        public Dictionary<int, Solar> protection = new Dictionary<int, Solar>();

        public Dictionary<int, int> pity = new Dictionary<int, int>();
    }

    public class Solar
    {
        public Solar(double _increase, int _limit)
        {
            increase = _increase;
            limit = _limit;
        }
        public double increase;
        public int limit;
    }
}