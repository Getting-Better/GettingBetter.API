﻿using GettingBetter.API.GettingBetter_System.Domain.Models;
using GettingBetter.API.GettingBetter_System.Domain.Repositories;
using GettingBetter.API.GettingBetter_System.Domain.Services;
using GettingBetter.API.GettingBetter_System.Domain.Services.Communication;
using GettingBetter.API.Shared.Domain.Repositories;

namespace GettingBetter.API.GettingBetter_System.Services
{

    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        private readonly IUnitOfWork _unitOfWork;
      

        public StudentService(IStudentRepository studentRepository, IUnitOfWork unitOfWork,
            ICoachRepository coachRepository)
        {
            _studentRepository = studentRepository;
            _unitOfWork = unitOfWork;
          
        }

        public async Task<IEnumerable<Student>> ListAsync()
        {
            return await _studentRepository.ListAsync();
        }

      

        public async Task<StudentResponse> SaveAsync(Student student)
        {
           


            try
            {
                // Add Student
                await _studentRepository.AddAsync(student);

                // Complete Transaction
                await _unitOfWork.CompleteAsync();

                // Return response
                return new StudentResponse(student);

            }
            catch (Exception e)
            {
                // Error Handling
                return new StudentResponse($"An error occurred while saving the student: {e.Message}");
            }


        }

        public async Task<StudentResponse> UpdateAsync(int studentId, Student student)
        {
            var existingStudent = await _studentRepository.FindByIdAsync(studentId);
            existingStudent.FirstName = student.FirstName;
            existingStudent.LastName = student.LastName;
            existingStudent.Password = student.Password;
            existingStudent.NickName = student.NickName;
            existingStudent.UserImage = student.UserImage;
            existingStudent.NickName = student.NickName;
            existingStudent.Email = student.Email;
            // Validate Student

            if (existingStudent == null)
                return new StudentResponse("Student not found.");

            // Validate CoachId

          

            try
            {
                _studentRepository.Update(existingStudent);
                await _unitOfWork.CompleteAsync();

                return new StudentResponse(existingStudent);

            }
            catch (Exception e)
            {
                // Error Handling
                return new StudentResponse($"An error occurred while updating the student: {e.Message}");
            }

        }

        public async Task<StudentResponse> DeleteAsync(int studentId)
        {
            var existingStudent = await _studentRepository.FindByIdAsync(studentId);

            // Validate Student

            if (existingStudent == null)
                return new StudentResponse("Student not found.");

            try
            {
                _studentRepository.Remove(existingStudent);
                await _unitOfWork.CompleteAsync();

                return new StudentResponse(existingStudent);

            }
            catch (Exception e)
            {
                // Error Handling
                return new StudentResponse($"An error occurred while deleting the student: {e.Message}");
            }

        }
    }
}