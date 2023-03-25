using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RovicareTestProject.Utilities
{
    public class ExtentTestManager
    {
        [ThreadStatic]
        private static ExtentTest _parentTest;


        public static ConcurrentDictionary<int,ExtentTest> testCollection = new ConcurrentDictionary<int,ExtentTest>();
        //[ThreadStatic]
        //private static ExtentTest _childTest;

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static ExtentTest CreateTest(string testName, string description = null)
        {
           // int threadId = Thread.CurrentThread.ManagedThreadId;
            _parentTest = ExtentManager.Instance.CreateTest(testName, description);//testName
           // testCollection.TryAdd(threadId, _parentTest);
            return _parentTest;
        }
        //[MethodImpl(MethodImplOptions.Synchronized)]
        //public  ExtentTest CreateTest(string testName, string description=null )
        //{
        //     int threadId = Thread.CurrentThread.ManagedThreadId;
        //    _parentTest = ExtentManager.Instance.CreateTest(testName, description);//testName
        //    testCollection.TryAdd(threadId, _parentTest);
        //    return _parentTest;
        //}

        //[MethodImpl(MethodImplOptions.Synchronized)]
        //public static ExtentTest CreateTest(string testName, string description = null)
        //{
        //    _childTest = _parentTest.CreateNode(testName, description);
        //    return _childTest;
        //}
        //[MethodImpl(MethodImplOptions.Synchronized)]
        //private void LogInfo(string message)
        //{
        //    int threadId = Thread.CurrentThread.ManagedThreadId;
        //    testCollection[threadId].Info(message);
        //}


        //[MethodImpl(MethodImplOptions.Synchronized)]
        //public static ExtentTest GetTest()
        //{
        //    return _childTest;
        //}
    }
}
