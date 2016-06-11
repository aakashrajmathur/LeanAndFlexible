using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NewHorizons
{
    class SelectionCreation
    {
        public Selection CreateSelection(Study study, double cutOff, string name = "", List<Part> alwaysIncluded = null, List<Part> neverIncluded = null, bool isSystemGenerated = false)
        {
            if (study == null)
                return null; 

            float maxRevenue = 0;
            float minRevenue = 0;
            float maxQuantity = 0;
            float minQuantity = 0;
            List<Element> partsIncludedInAnalysis = new List<Element>();

            foreach(Part p in study.parts)
            {
                if (neverIncluded != null)
                {
                    if (neverIncluded.Contains(p))
                    {
                        continue;
                    }
                }
                if (alwaysIncluded != null)
                {
                    if (alwaysIncluded.Contains(p))
                    {
                        continue;
                    }
                }

                if (p.revenue >= maxRevenue)
                {
                    maxRevenue = p.revenue; 
                }
                if(p.revenue < minRevenue)
                {
                    minRevenue = p.revenue; 
                }
                if(p.quantity > maxQuantity)
                {
                    maxQuantity = p.quantity;
                }
                if(p.quantity < minQuantity)
                {
                    minQuantity = p.quantity;
                }
            }

            foreach(Part p in study.parts)
            {
                float score = getCurrentPartsScore(p.revenue, p.quantity, minRevenue, maxRevenue, minQuantity, maxQuantity);
                Element e = new Element(p, score);
                partsIncludedInAnalysis.Add(e);
            }

            partsIncludedInAnalysis.Sort();
            partsIncludedInAnalysis.Reverse();

            ////////////////////////////////////////////////////

            int countIncluded = (int)Math.Round(partsIncludedInAnalysis.Count * (cutOff / 100.0));
            
            Selection selection = new Selection();
            selection.name = name;
            selection.isSystemCreated = isSystemGenerated;

            //Add Always included: 
            if(alwaysIncluded != null)
            {
                selection.partsAlwaysIncluded = alwaysIncluded;
            }
            if(neverIncluded!= null)
            {
                selection.partsNeverIncluded = neverIncluded;
            }

            if (countIncluded > 0)
            {
                for (int i = 0; i < countIncluded; i++)
                {
                    selection.partsIncluded.Add(partsIncludedInAnalysis[i].part);
                }
            }
            foreach(Element e in partsIncludedInAnalysis)
            {
                if (!selection.partsIncluded.Contains(e.part))
                {
                    selection.partsNotIncluded.Add(e.part);
                }
            }
            //MessageBox.Show("Count of parts in " + name + Environment.NewLine + 
           //     "Always Included = " + selection.partsAlwaysIncluded.Count.ToString() + Environment.NewLine +
            //    "Included = " + selection.partsIncluded.Count.ToString() + Environment.NewLine +
              //  "Not Included = " + selection.partsNotIncluded.Count.ToString() + Environment.NewLine +
                //"Never Included = " + selection.partsNeverIncluded.Count.ToString() + Environment.NewLine);
            return selection; 
        }

        private float getCurrentPartsScore(float revenue, float quantity, float minRevenue, float maxRevenue, float minQuantity, float maxQuantity)
        {

            float Q_star = (quantity - minQuantity) / (maxQuantity - minQuantity);
            float R_star = (revenue - minRevenue) / (maxRevenue - minRevenue);

            return (float)Math.Sqrt((Q_star * Q_star) + (R_star * R_star));
        }
    }

    class Element : IComparable<Element>
    {
        public Part part;
        public float score; 

        public Element(Part p, float s)
        {
            this.part = p;
            this.score = s;
        }

        public int CompareTo(Element other)
        {
            if(this.score == other.score) { return 0; }else if(this.score > other.score) { return +1; } else { return -1; }
        }
    }
}
