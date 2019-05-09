using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kasyno.Data;
using Kasyno.MainLogic;

namespace UnitTest
{
    [TestClass]
    class DataRepositoryTests
    {
        DataContext data;
        DataFiller filler;
        DataRepository dataRepository;

        [TestInitialize]
        public void InitializeTests()
        {
            data = new DataContext();
            filler = new ConstantFiller();
            dataRepository = new DataRepository(filler, data);
        }
    }
}
