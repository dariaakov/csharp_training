using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData newData = new GroupData("y");
            newData.Header = null;
            newData.Footer = null;

            app.Groups.GroupIsPresent();
            app.Groups.Modify(1, newData);
        }
    }
}
