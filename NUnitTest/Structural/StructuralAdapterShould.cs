using MoreLinq;
using NUnit.Framework;
using Pattern.Structural.Adapter;
using Pattern.Structural.Adapter.Interfaces;
using Pattern.Structural.Adapter.Managers;
using Pattern.Structural.Adapter.Models;
using System.Collections.Generic;

namespace NUnitTest.Structural
{
    public class StructuralAdapterShould
    {
        IDrawPoint manager;
        List<Vector> vectors;

        [SetUp()]
        public void Setup()
        {
            manager = new PointManager();
            vectors = new List<Vector>
            {
                new Rectangle(1, 1, 10, 10),
                new Rectangle(1, 1, 10, 10),
                new Rectangle(3, 3, 6, 6),
                new Rectangle(3, 3, 6, 6)
            };
        }

        [Test()]
        public void DrawVectorRectangles()
        {
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

            Assert.AreEqual(76, manager.GetTotal());

            foreach (var vector in vectors)
            {
                foreach (var line in vector)
                {
                    var adapter = new LineToPointCacheAdapter(line);
                    adapter.ForEach(p =>
                    {
                        manager.Draw(p);
                    });
                }
            }

            Assert.AreEqual(540, manager.GetTotal());
        }
    }
}
