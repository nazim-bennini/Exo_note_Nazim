using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serie_IV
{
    public class BusinessSchedule
    {
            private Dictionary<DateTime, TimeSpan> _agenda;
            private DateTime _begindate { get; set; }
            private DateTime _enddate { get; set; }


            public BusinessSchedule()                                     //constructeur
            {
                _agenda = new Dictionary<DateTime, TimeSpan>();          // initialization du dictionnaire
                DateTime begindate = new DateTime(2000,01,01);
                DateTime enddate = new DateTime(2049,12,31);
            }

        public bool IsEmpty()
        {
            if (_agenda.Count != 0)
            {
                return false;
            }
            else 
            {
                return true;
            }
        }


        public void SetRangeOfDates(DateTime begin, DateTime end)
        {
            if (!IsEmpty())  // c.f Non vide
            {
                _begindate = begin;
                _enddate = end;
            }
            else
            {
                throw new Exception("!");
            }
        }

        private KeyValuePair<DateTime, DateTime> ClosestElements(DateTime beginMeeting)
        {
            DateTime lower = DateTime.MinValue, upper = DateTime.MaxValue;

            foreach(DateTime meeting in _agenda.Keys)
            {
                if (beginMeeting >= meeting)
                {
                    lower = meeting;
                }
                else if (beginMeeting <= meeting)
                {
                    upper = meeting;
                    break;
                }
            }

            return new KeyValuePair<DateTime, DateTime>();
        }

        public bool AddBusinessMeeting(DateTime date, TimeSpan duration)
        {
            //TODO
            return false;
        }

        public bool DeleteBusinessMeeting(DateTime date, TimeSpan duration)
        {
            //TODO
            return false;
        }

        public int ClearMeetingPeriod(DateTime begin, DateTime end)
        {
            //TODO
            return -1;
        }

        public void DisplayMeetings()
        {
            //TODO
        }
    }
}
