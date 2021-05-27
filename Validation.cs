using System;
using System.Linq;
using Lab2.Models;

namespace Lab2
{
    public class Validation
    {
        public class UniversityValid
        {
            Lab2Context _context;
            University university;
            public UniversityValid(Lab2Context context, University university)
            {
                _context = context;
                this.university = university;
            }

            public bool Valid()
            {
                var universities = _context.University.Where(a => a.Name == university.Name).ToList();
                if (universities.Count != 0) if (universities.Count == 1)
                    { if (universities[0].Id == university.Id) return true; else return false; } else return false;
                else return true;
            }
        }

        public class CampusValid
        {
            // !!!!!!!!!!!!!!!!!!!!!
            Lab2Context _context;
            Campus campus;
            public CampusValid(Lab2Context context, Campus campus)
            {
                _context = context;
                this.campus = campus;
            }

            public bool Valid()
            {
                var campusis = _context.Campus.Where(a => a.University == campus.University).ToList();
                if (campusis.Count != 0) if (campusis.Count == 1) { if (campusis[0].Id == campus.Id) return true; else return false; } else return false;
                else return true;
            }
        }
        public class DormValid
        {
            Lab2Context _context;
            Dormitory dormitory;
            public DormValid(Lab2Context context, Dormitory dormitory)
            {
                _context = context;
                this.dormitory = dormitory;
            }

            public bool Valid()
            {
                var dorm = _context.Dormitory.Where(a => a.CampusId == dormitory.CampusId).Where(a => a.Number == dormitory.Number).ToList();
                if (dorm.Count != 0) if (dorm.Count == 1) { if (dorm[0].Id == dormitory.Id) return true; else return false; } else return false;

                var dorms = _context.Dormitory.Where(a => a.AdressStreet == dormitory.AdressStreet).Where(a => a.AdressNumber == dormitory.AdressNumber).ToList();
                if (dorms.Count != 0) if (dorms.Count == 1) { if (dorms[0].Id == dormitory.Id) return true; else return false; } else return false;

                else return true;
            }
        }

        public class FloorValid
        {
            Lab2Context _context;
            Floor floor;
            public FloorValid(Lab2Context context, Floor floor)
            {
                _context = context;
                this.floor = floor;
            }

            public bool Valid()
            {
                var flooris = _context.Floor.Where(a => a.Number == floor.Number).Where(a => a.DormId == floor.DormId).ToList();
                if (flooris.Count != 0) if (flooris.Count == 1) { if (flooris[0].Id == floor.Id) return true; else return false; } else return false;
                else return true;
            }
        }
        public class BlokValid
        {
            Lab2Context _context;
            Blok blok;
            public BlokValid(Lab2Context context, Blok blok)
            {
                _context = context;
                this.blok = blok;
            }

            public bool Valid()
            {
                var bloks = _context.Blok.Where(a => a.Number == blok.Number).Where(a => a.FloorId == blok.FloorId).ToList();
                if (bloks.Count != 0) if (bloks.Count == 1) { if (bloks[0].Id == blok.Id) return true; else return false; } else return false;
                else return true;
            }
        }
        public class RoomValid
        {
            Lab2Context _context;
            Room room;
            public RoomValid(Lab2Context context, Room room)
            {
                _context = context;
                this.room = room;
            }

            public bool Valid()
            {
                var rooms = _context.Blok.Where(a => a.Number == room.Number).Where(a => a.Id == room.BlokId).ToList();
                if (rooms.Count != 0) if (rooms.Count == 1) { if (rooms[0].Id == room.Id) return true; else return false; } else return false;
                else return true;
            }
        }
    }
}
