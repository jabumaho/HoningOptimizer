using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace HoningOptimizer
{
    public class Optimizer
    {
        private HoningData data;
        public Optimizer(HoningData _data)
        {
            data = _data;
        }

        public List<double> optimize(double goldPerAttempt, int level, int gracegold, int blessinggold, int protgold, bool stronghold, bool book)
        {
            List<double> minExpectedGold = new List<double>() {0, 0, 0, Double.MaxValue};
            
            for (int g = 0; g <= data.grace[level].limit; g++)
            {
                for (int b = 0; b <= data.blessing[level].limit; b++)
                {
                    for (int p = 0; p <= data.protection[level].limit; p++)
                    {
                        double newCost = goldPerAttempt + g * gracegold + b * blessinggold + p * protgold;
                        double newChance = data.chances[level] + g * data.grace[level].increase +
                                           b * data.blessing[level].increase + p * data.protection[level].increase;
                        if (stronghold)
                            newChance += 0.1;
                        if (book)
                            newChance += 0.1;
                        if (newChance > 1)
                            newChance = 1;
                        double exp = getExpectedCost(newCost, newChance, level);
                        if (exp < minExpectedGold[3])
                            minExpectedGold = new List<double>() { g, b, p, exp };
                    }
                }
            }

            return minExpectedGold;
        }

        public double getExpectedCost(double goldPerAttempt, double chance, int level)
        {
            double chanceBonus = data.chances[level] / 10;
            Node start = new Node() { layer = 0, gold = 0, prob = 1 };
            Node curr = start;
            double expected_gold = 0;
            double artisan = 0;
            for (int i = 1; i <= data.pity[level]; i++)
            {
                curr.success = new Node() { layer = i, gold = curr.gold + goldPerAttempt, prob = curr.prob * chance };
                curr.fail = new Node() { layer = i , gold = curr.gold + goldPerAttempt, prob = curr.prob*(1-chance) };
                
                artisan += chance * 0.465;
                expected_gold += curr.success.gold * curr.success.prob;
                
                if (chance == 1)
                    break;
                chance += chanceBonus;
                if (artisan >= 1 || chance > 1)
                    chance = 1;
                
                curr = curr.fail;
                
            }

            return expected_gold;
        }
    }

    public class Node
    {
        public Node success;
        public Node fail;
        public int layer;
        public double gold;
        public double prob;
    }
}