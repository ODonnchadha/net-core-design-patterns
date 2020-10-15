using MoreLinq;
using NUnit.Framework;
using Structural.Adapter;
using Structural.Adapter.Interfaces;
using Structural.Adapter.Managers;
using Structural.Adapter.Models;
using System.Collections.Generic;

namespace NUnitTest
{
    public class StructuralAdapterShould
    {
        [SetUp()]
        public void Setup()
        {
        }

        [Test()]
        public void DrawVectorRectangles()
        {
            IDrawPoint manager = new PointManager();
            List<Vector> vectors = new List<Vector>
            {
                new Rectangle(1, 1, 10, 10),
                new Rectangle(3, 3, 6, 6)
            };

            foreach (var vector in vectors)
            {
                foreach(var line in vector)
                {
                    var adapter = new LineToPointAdapter(line);
                    adapter.ForEach(p =>
                    {
                        manager.Draw(p);
                    });
                }
            }

            Assert.AreEqual(38, manager.GetTotal());
        }
    }
}
