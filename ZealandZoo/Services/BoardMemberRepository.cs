using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using ZealandZoo.Interface;
using ZealandZoo.Models;

namespace ZealandZoo.Services
{
    public class BoardMemberRepository(ApplicationDbContext _context, IWebHostEnvironment _environment) : IBoardMemberRepository
    {

        // Constructor to initialize context


        //Create
        public void CreateBoardMember(BoardMemberDto boardMemberDto)
        {
            BoardMember boardMemberToBeCreated = new BoardMember()
            {
                FirstName = boardMemberDto.FirstName,
                LastName = boardMemberDto.LastName,
                Description = boardMemberDto.Description,
                AreaOfResponsibility = boardMemberDto.AreaOfResponsibility,
                StudyProgramme = boardMemberDto.StudyProgramme,
                Semester = boardMemberDto.Semester,
                ImageFileName = SaveImageAsFile(boardMemberDto),
            }
            ;


            _context.BoardMembers.Add(boardMemberToBeCreated);
            _context.SaveChanges();
        }

        public string SaveImageAsFile(BoardMemberDto boardMemberDto)
        {
            string newImageFileName;
            string fullImageFilePath;

            // save Image as a file
            newImageFileName = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            newImageFileName += Path.GetExtension(boardMemberDto.ImageFile!.FileName);

            fullImageFilePath = _environment.WebRootPath + "/images/boardMembers/" + newImageFileName;
            using (FileStream? stream = System.IO.File.Create(fullImageFilePath))
            {
                boardMemberDto.ImageFile.CopyTo(stream);
            }
            return newImageFileName;
        }

        //Read
        public List<BoardMember> GetAlBoardMembers()
        {
            return _context.BoardMembers.ToList();
        }
        public List<BoardMember> FilterBoardMembersBySemester(int providedSemester)
        {
            List<BoardMember> filteredBoardMemberList = new List<BoardMember>();

            foreach (BoardMember existingBoardMember in GetAlBoardMembers())
            {
                if (existingBoardMember.Semester == providedSemester)
                {
                    filteredBoardMemberList.Add(existingBoardMember);
                }
            }
            return filteredBoardMemberList;
        }

        public BoardMember GetBoardMemberById(int id)
        {
            if (id <= 0)
            {
                return null; // Invalid ID
            }

            var boardMember = _context.BoardMembers.Find(id);

            /*if (boardMember == null)
            {
                // Log or handle the case where the entity is not found
                // Example: throw an exception or return a specific response
                // throw new KeyNotFoundException($"Board member with ID {id} was not found.");
            }*/

            return boardMember; // Can be null if not found
        }

        //Update
        public void UpdateBoardMember(BoardMemberDto boardMemberDto)
        {
            BoardMember boardMemberToBeUpdated = GetBoardMemberById(boardMemberDto.BoardMemberId);

            boardMemberToBeUpdated.FirstName = boardMemberDto.FirstName;
            boardMemberToBeUpdated.LastName = boardMemberDto.LastName;
            boardMemberToBeUpdated.Description = boardMemberDto.Description;
            boardMemberToBeUpdated.AreaOfResponsibility = boardMemberDto.AreaOfResponsibility;
            boardMemberToBeUpdated.StudyProgramme = boardMemberDto.StudyProgramme;
            boardMemberToBeUpdated.Semester = boardMemberDto.Semester;
            boardMemberToBeUpdated.ImageFileName = UpdateImageFile(GetBoardMemberById(boardMemberDto.BoardMemberId), boardMemberDto);

            _context.SaveChanges();
        }

        public string UpdateImageFile(BoardMember boardMember, BoardMemberDto boardMemberDto)
        {
            string newImageFileName;
            string imageFullPath;

            if (boardMemberDto.ImageFile == null)
            {
                return boardMember.ImageFileName;
            }
            else
            {
                newImageFileName = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                newImageFileName += Path.GetExtension(boardMemberDto.ImageFile!.FileName);

                // Save the new image file
                imageFullPath = _environment.WebRootPath + "/images/boardMembers/" + newImageFileName;
                using (FileStream? stream = System.IO.File.Create(imageFullPath))
                {
                    boardMemberDto.ImageFile.CopyTo(stream);
                }

                // Delete old image file
                DeleteImage(boardMember);

                return newImageFileName;
            }
        }

        //Delete
        public void DeleteBoardMember(BoardMemberDto boardMemberDto)
        {
            _context.BoardMembers.Remove(GetBoardMemberById(boardMemberDto.BoardMemberId));
            _context.SaveChanges();
        }

        public void DeleteImage(BoardMember boardMember)
        {
            string oldImageFullPath;

            oldImageFullPath = _environment.WebRootPath + "/images/boardMembers/" + boardMember.ImageFileName;
            System.IO.File.Delete(oldImageFullPath);
        }

        //Clear
        public void ClearBoardMemberDto(BoardMemberDto boardMemberDto)
        {
            boardMemberDto.FirstName = "";
            boardMemberDto.LastName = "";
            boardMemberDto.Description = "";
            boardMemberDto.AreaOfResponsibility = "";
            boardMemberDto.StudyProgramme = "";
            boardMemberDto.Semester = 0;
            boardMemberDto.ImageFile = null;
        }
    }
}
