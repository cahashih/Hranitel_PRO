using SF2022User_NN_Lib;

namespace ClassCalculationTest
{
    public class TestLib
    {
        [Fact]
        public void Test1()
        {
            List<TimeSpan> startTimes = new List<TimeSpan>()
                                                            {
                                                            new TimeSpan(10,0,0),new TimeSpan(11,0,0),
                                                            new TimeSpan(15,0,0), new TimeSpan(15,30,0),
                                                            new TimeSpan(16,50,0)
                                                            };
            List<int> durations = new List<int>() { 60, 30, 10, 10, 40 };
            TimeSpan beginWorkingTime = new TimeSpan(8, 0, 0); // Часы, минуты, секунды
            TimeSpan endWorkingTime = new TimeSpan(18, 0, 0); // Часы, минуты, секунды
            int consultationTime = 30;
            var calc = new Calculation();
            string[] expected = {
                "08:00-08:30",
                "08:30-09:00",
                "09:00-09:30",
                "09:30-10:00",
                "11:30-12:00",
                "12:00-12:30",
                "12:30-13:00",
                "13:00-13:30",
                "13:30-14:00",
                "14:00-14:30",
                "14:30-15:00",
                "15:40-16:10",
                "16:10-16:40",
                "17:30-18:00"};
            string[] actual = calc.AvailablePeriods(startTimes, durations, beginWorkingTime, endWorkingTime, consultationTime);
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Test2()
        {
            List<TimeSpan> startTimes = new List<TimeSpan>()
                                                            {
                                                            new TimeSpan(11,30,0),new TimeSpan(12,10,0),
                                                            new TimeSpan(15,20,0), new TimeSpan(15,30,0),
                                                            new TimeSpan(17,20,0)
                                                            };
            List<int> durations = new List<int>() { 40, 30, 10, 40, 10 };
            TimeSpan beginWorkingTime = new TimeSpan(8, 0, 0); // Часы, минуты, секунды
            TimeSpan endWorkingTime = new TimeSpan(18, 0, 0); // Часы, минуты, секунды
            int consultationTime = 30;
            var calc = new Calculation();
            string[] expected = {
                "08:00-08:30",
                "08:30-09:00",
                "09:00-09:30",
                "09:30-10:00",
                "10:00-10:30",
                "10:30-11:00",
                "11:00-11:30",
                "12:40-13:10",
                "13:10-13:40",
                "13:40-14:10",
                "14:10-14:40",
                "14:40-15:10",
                "16:10-16:40",
                "16:40-17:10",
                "17:30-18:00"};
            string[] actual = calc.AvailablePeriods(startTimes, durations, beginWorkingTime, endWorkingTime, consultationTime);
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Test3()
        {
            List<TimeSpan> startTimes = new List<TimeSpan>()
                                                            {
                                                            new TimeSpan(10,00,0),new TimeSpan(12,30,0),
                                                            new TimeSpan(15,20,0), new TimeSpan(15,30,0), new TimeSpan(16,50,0)
                                                            };
            List<int> durations = new List<int>() { 40, 30, 40, 30, 40};
            TimeSpan beginWorkingTime = new TimeSpan(10, 0, 0); // Часы, минуты, секунды
            TimeSpan endWorkingTime = new TimeSpan(20, 0, 0); // Часы, минуты, секунды
            int consultationTime = 30;
            var calc = new Calculation();
            string[] expected = {
                "10:40-11:10",
                "11:10-11:40",
                "11:40-12:10",
                "13:00-13:30",
                "13:30-14:00",
                "14:00-14:30",
                "14:30-15:00",
                "16:00-16:30",
                "16:30-17:00",
                "17:00-17:30",
                "17:30-18:00",
                "18:00-18:30",
                "18:30-19:00",
                "19:00-19:30",
                "19:30-20:00",
};
            string[] actual = calc.AvailablePeriods(startTimes, durations, beginWorkingTime, endWorkingTime, consultationTime);
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Test4()
        {
            List<TimeSpan> startTimes = new List<TimeSpan>()
                                                            {
                                                            new TimeSpan(10,20,0),new TimeSpan(11,0,0),
                                                            new TimeSpan(15,0,0), new TimeSpan(15,30,0),
                                                            new TimeSpan(16,50,0)
                                                            };
            List<int> durations = new List<int>() { 60, 30, 10, 10, 40 };
            TimeSpan beginWorkingTime = new TimeSpan(10, 0, 0); // Часы, минуты, секунды
            TimeSpan endWorkingTime = new TimeSpan(20, 0, 0); // Часы, минуты, секунды
            int consultationTime = 20;
            var calc = new Calculation();
            string[] expected = {
                "10:00-10:20",
                "11:20-11:40",
                "11:40-12:00",
                "12:00-12:20",
                "12:20-12:40",
                "12:40-13:00",
                "13:00-13:20",
                "13:20-13:40",
                "13:40-14:00",
                "14:00-14:20",
                "14:20-14:40",
                "14:40-15:00",
                "15:00-15:20",
                "15:20-15:40",
                "15:40-16:00",
                "16:00-16:20",
                "16:20-16:40",
                "16:40-17:00",
                "17:00-17:20",
                "17:20-17:40",
                "17:40-18:00",
                "18:00-18:20",
                "18:20-18:40",
                "18:40-19:00",
                "19:00-19:20",
                "19:20-19:40",
                "19:40-20:00",

};
            string[] actual = calc.AvailablePeriods(startTimes, durations, beginWorkingTime, endWorkingTime, consultationTime);
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Test5()
        {
            List<TimeSpan> startTimes = new List<TimeSpan>()
                                                            {
                                                            new TimeSpan(10,30,0),new TimeSpan(11,0,0),
                                                            new TimeSpan(15,0,0), new TimeSpan(15,30,0),
                                                            new TimeSpan(16,50,0)
                                                            };
            List<int> durations = new List<int>() { 60, 30, 10, 10, 40 };
            TimeSpan beginWorkingTime = new TimeSpan(10, 0, 0); // Часы, минуты, секунды
            TimeSpan endWorkingTime = new TimeSpan(20, 0, 0); // Часы, минуты, секунды
            int consultationTime = 60;
            var calc = new Calculation();
            string[] expected = {
                "11:30-12:30",
                "12:30-13:30",
                "13:30-14:30",
                "14:30-15:30",
                "15:30-16:30",
                "16:30-17:30",
                "17:30-18:30",
                "18:30-19:30",
                "19:30-20:30",

};
            string[] actual = calc.AvailablePeriods(startTimes, durations, beginWorkingTime, endWorkingTime, consultationTime);
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Test6()
        {
            List<TimeSpan> startTimes = new List<TimeSpan>()
                                                            {
                                                            new TimeSpan(10,30,0),new TimeSpan(11,0,0),
                                                            new TimeSpan(15,0,0), new TimeSpan(15,30,0),
                                                            new TimeSpan(20,20,0)
                                                            };
            List<int> durations = new List<int>() { 60, 30, 10, 10, 40 };
            TimeSpan beginWorkingTime = new TimeSpan(10, 0, 0); // Часы, минуты, секунды
            TimeSpan endWorkingTime = new TimeSpan(20, 0, 0); // Часы, минуты, секунды
            int consultationTime = 60;
            var calc = new Calculation();
            string[] expected = {
                "11:30-12:30",
                "12:30-13:30",
                "13:30-14:30",
                "14:30-15:30",
                "15:30-16:30",
                "16:30-17:30",
                "17:30-18:30",
                "18:30-19:30",
                "19:30-20:30",


};
            string[] actual = calc.AvailablePeriods(startTimes, durations, beginWorkingTime, endWorkingTime, consultationTime);
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Test7()
        {
            List<TimeSpan> startTimes = new List<TimeSpan>()
                                                            {
                                                            new TimeSpan(9,30,0),new TimeSpan(11,0,0),
                                                            new TimeSpan(15,0,0), new TimeSpan(15,30,0),
                                                            new TimeSpan(20,10,0)
                                                            };
            List<int> durations = new List<int>() { 60, 30, 10, 10, 10 };
            TimeSpan beginWorkingTime = new TimeSpan(10, 0, 0); // Часы, минуты, секунды
            TimeSpan endWorkingTime = new TimeSpan(20, 0, 0); // Часы, минуты, секунды
            int consultationTime = 60;
            var calc = new Calculation();
            string[] expected = {
                "10:00-11:00","11:00-12:00","12:00-13:00","13:00-14:00","14:00-15:00","15:00-16:00","16:00-17:00","17:00-18:00","18:00-19:00","19:00-20:00",



};
            string[] actual = calc.AvailablePeriods(startTimes, durations, beginWorkingTime, endWorkingTime, consultationTime);
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Test8()
        {
            List<TimeSpan> startTimes = new List<TimeSpan>()
                                                            {
                                                            new TimeSpan(9,30,0),new TimeSpan(11,0,0),
                                                            new TimeSpan(15,0,0), new TimeSpan(15,30,0),
                                                            new TimeSpan(19,0,0)
                                                            };
            List<int> durations = new List<int>() { 60, 30, 10, 10, 10 };
            TimeSpan beginWorkingTime = new TimeSpan(8, 0, 0); // Часы, минуты, секунды
            TimeSpan endWorkingTime = new TimeSpan(20, 0, 0); // Часы, минуты, секунды
            int consultationTime = 50;
            var calc = new Calculation();
            string[] expected = {
                "08:00-08:50","11:30-12:20","12:20-13:10","13:10-14:00","14:00-14:50","15:40-16:30","16:30-17:20","17:20-18:10","18:10-19:00","19:10-20:00"
                };
            string[] actual = calc.AvailablePeriods(startTimes, durations, beginWorkingTime, endWorkingTime, consultationTime);
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Test9()
        {
            List<TimeSpan> startTimes = new List<TimeSpan>()
                                                            {
                                                            new TimeSpan(9,30,0),new TimeSpan(11,0,0),
                                                            new TimeSpan(15,0,0), new TimeSpan(15,30,0),
                                                            new TimeSpan(19,0,0)
                                                            };
            List<int> durations = new List<int>() { 60, 30, 10, 10, 30 };
            TimeSpan beginWorkingTime = new TimeSpan(8, 0, 0); // Часы, минуты, секунды
            TimeSpan endWorkingTime = new TimeSpan(20, 0, 0); // Часы, минуты, секунды
            int consultationTime = 30;
            var calc = new Calculation();
            string[] expected = {
                "08:00-08:30","08:30-09:00","09:00-09:30","10:30-11:00","11:30-12:00","12:00-12:30","12:30-13:00","13:00-13:30","13:30-14:00","14:00-14:30","14:30-15:00","15:40-16:10","16:10-16:40","16:40-17:10","17:10-17:40","17:40-18:10","18:10-18:40","19:30-20:00",

                };
            string[] actual = calc.AvailablePeriods(startTimes, durations, beginWorkingTime, endWorkingTime, consultationTime);
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Test10()
        {
            List<TimeSpan> startTimes = new List<TimeSpan>()
                                                            {
                                                            new TimeSpan(9,30,0),new TimeSpan(11,0,0),
                                                            new TimeSpan(15,0,0), new TimeSpan(15,30,0),
                                                            new TimeSpan(18,0,0)
                                                            };
            List<int> durations = new List<int>() { 60, 30, 10, 10, 30 };
            TimeSpan beginWorkingTime = new TimeSpan(8, 0, 0); // Часы, минуты, секунды
            TimeSpan endWorkingTime = new TimeSpan(20, 0, 0); // Часы, минуты, секунды
            int consultationTime = 90;
            var calc = new Calculation();
            string[] expected = {
                "08:00-09:30","11:30-13:00","13:00-14:30","15:40-17:10","18:30-20:00"

                };
            string[] actual = calc.AvailablePeriods(startTimes, durations, beginWorkingTime, endWorkingTime, consultationTime);
            Assert.Equal(expected, actual);
        }
    }
}