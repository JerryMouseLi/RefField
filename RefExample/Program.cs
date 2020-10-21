using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace RefExample
{
    class Program
    {
        static void Main(string[] args)
        {
   //        #region 属性性能测试
   //     Point[] points = new Point[1000000];
   //     Initializ(points);
   //    // InitializList();
   //    var bigRunTime = DateTime.Now;
   //    for (int i = 0; i < points.Length; i++)
   //    {
   //        int x = points[i].X;
   //        int y = points[i].Y;
   //         TransformPoint(ref x, ref y);
   //        points[i].X = x;
   //        points[i].Y = y;
   //    }
   //    var endRunTime = DateTime.Now;
   //    var timeSpend=ExecDateDiff(bigRunTime,endRunTime);
   //    Console.WriteLine("变换后首元素坐标：{0},{1}",points[0].X,points[0].Y);
   //    
   //    Console.WriteLine("属性赋值执行花费时间：{0}",timeSpend);
   //       #endregion
           
        #region 字段性能测试
        PointField[] points = new PointField[1000000];
        InitializField(points);
        // InitializList();
        var bigRunTime = DateTime.Now;
        for (int i = 0; i < points.Length; i++)
        {
            TransformPoint(ref points[i].X, ref points[i].Y);
        }
        var endRunTime = DateTime.Now;
        var timeSpend=ExecDateDiff(bigRunTime,endRunTime);
        Console.WriteLine("变换后首元素坐标：{0},{1}",points[0].X,points[0].Y);
        
        Console.WriteLine("字段赋值执行花费时间：{0}",timeSpend);
        #endregion
        }

        /// 程序执行时间测试
        /// </summary>
        /// <param name="dateBegin">开始时间</param>
        /// <param name="dateEnd">结束时间</param>
        /// <returns>返回(秒)单位，比如: 0.00239秒</returns>
        public static string ExecDateDiff(DateTime dateBegin, DateTime dateEnd)
        {
            TimeSpan ts1 = new TimeSpan(dateBegin.Ticks);
            TimeSpan ts2 = new TimeSpan(dateEnd.Ticks);
            TimeSpan ts3 = ts1.Subtract(ts2).Duration();
            //你想转的格式
             return ts3.TotalMilliseconds.ToString();
        }
        static Point[] Initializ(Point[] points)
        {
            
            for (int i = 0; i < points.Length; i++)
           {
              points[i] =new Point();
              points[i].X = 1;
              points[i].Y = 2;
           }

           Console.WriteLine("首元素坐标：{0},{1}",points[0].X,points[0].Y);
            return points;
        }
        
        static PointField[] InitializField(PointField[] points)
        {
            
            for (int i = 0; i < points.Length; i++)
            {
                points[i] =new PointField();
                points[i].X = 1;
                points[i].Y = 2;
            }

            Console.WriteLine("首元素坐标：{0},{1}",points[0].X,points[0].Y);
            return points;
        }

        static List<Point> InitializList()
        {
            List<Point> points = new List<Point>();
            for (var i = 0; i < 1000000; i++)
            {
                points.Add(new Point());
            }

            foreach (var item in points)
            {
                item.X = 1;
                item.Y = 2;
            }
            Console.WriteLine("首元素坐标：{0},{1}",points[0].X,points[0].Y);

            return points;

        }
        

        static void TransformPoint(ref int x, ref int y)
        {
            x = 3;
            y = 4;
        }

    }
}