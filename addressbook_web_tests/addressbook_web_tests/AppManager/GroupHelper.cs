﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class GroupHelper : HelperBase
    {
        public GroupHelper(ApplicationManager manager) : base(manager)
        {
        }

        public GroupHelper Create(GroupData group)
        {
            manager.Navigator.GoToGroupsPage();
            InitGroupCreation();
            FillGroupForm(group);
            SubmitGroupCreation();
            manager.Navigator.GoToGroupsPage();
            return this;
        }

        public GroupHelper Modify(int i, GroupData newData)
        {
            if ()
            {
                return;
            }


            manager.Navigator.GoToGroupsPage();
            SelectGroup(i);
            InitGroupModification();
            FillGroupForm(newData);
            SubmitGroupModification();
            manager.Navigator.GoToGroupsPage();
            return this;
        }

        public GroupHelper Remove(int i)
        {
            manager.Navigator.GoToGroupsPage();
            SelectGroup(i);
            RemoveGroup();
            manager.Navigator.GoToGroupsPage();
            return this;
        }

        public GroupHelper InitGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }

        public GroupHelper FillGroupForm(GroupData group)
        {
            Type(By.Name("group_name"), group.Name);
            Type(By.Name("group_header"), group.Header);
            Type(By.Name("group_footer"), group.Footer);
            return this;
        }

        public GroupHelper SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }

        public GroupHelper SelectGroup(int index)
        {
            if (HelperBase.IsElementPresent(By.Id(index)))
            {
                driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + "]")).Click();
                return this;
            }
            Create(GroupData group);
        }

        public GroupHelper RemoveGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
            return this;
        }

        public GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public GroupHelper InitGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }
    }
}
