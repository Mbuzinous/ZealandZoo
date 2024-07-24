using ZealandZoo.Models;

namespace ZealandZoo.Interface
{
    public interface IBoardMemberRepository
    {
        //Create
        void CreateBoardMember(BoardMemberDto boardMemberDto);

        //Read
        List<BoardMember> GetAlBoardMembers();
        BoardMember GetBoardMemberById(int id);
        List<BoardMember> FilterBoardMembersBySemester(int providedSemester);

        //Update
        void UpdateBoardMember(BoardMemberDto boardMemberDto);

        //Delete
        void DeleteBoardMember(BoardMemberDto boardMemberDto);

        //Clear
        void ClearBoardMemberDto(BoardMemberDto boardMemberDto);

    }
}
