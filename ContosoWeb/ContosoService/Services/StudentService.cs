﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Transactions;
using ContosoData.Repositories;
using ContosoModels.Models;

namespace ContosoService.Services
{
    public class StudentService : IStudentService
    {
        private readonly IPersonRepository _personRepository;
        private readonly IStudentRepository _studentRepository;

        public StudentService(IPersonRepository personRepository, IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
            _personRepository = personRepository;
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return _studentRepository.GetAll();
        }

        public Student GetStudentById(int id)
        {
            return _studentRepository.GetById(id);
        }

        public IEnumerable<Student> GetStudentByName(string name)
        {
            return _studentRepository.GetMany(s => s.LastName.Contains(name) || s.FirstName.Contains(name)).ToList();
        }

        public void CreateStudent(Student student)
        {
            using (var transaction = new TransactionScope())
            {
                _personRepository.Add(student);
                _personRepository.SaveChanges();
                transaction.Complete();
            }
        }

        public void UpdateStudent(Student student)
        {
            using (var transaction = new TransactionScope())
            {
                _personRepository.Update(student);
                _personRepository.SaveChanges();
                transaction.Complete();
            }
        }

    }

    public interface IStudentService
    {
        IEnumerable<Student> GetAllStudents();
        Student GetStudentById(int id);
        IEnumerable<Student> GetStudentByName(string name);
        void CreateStudent(Student student);
        void UpdateStudent(Student student);
    }
}