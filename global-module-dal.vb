' global module dal
' 数据访问层模块
' 用于访问数据库的基本操作

Public Interface IBaseDAO

    Function Find(Of T)(ByVal obj As T) As T

    Function Query(Of T)(ByVal obj As T) As IList(Of T)

    Function Insert(Of T)(ByVal obj As T) As Boolean

    Function Update(Of T)(ByVal obj As T) As Boolean

    Function Delete(Of T)(ByVal obj As T) As Boolean

End Interface

Public Class OrganizationDAO : Implements IBaseDAO

    Private Const TABLE_NAME As String = "Organization"

    Public Sub New()   '构造函数
        output.show("Object is being created")
    End Sub

    Function Find(Of DTO.OrganizationDTO)(ByVal obj As DTO.OrganizationDTO) As DTO.OrganizationDTO Implements IBaseDAO.Find
        output.show("Find is invoke")
        Return Nothing
    End Function

    Function Query(Of DTO.OrganizationDTO)(ByVal obj As DTO.OrganizationDTO) As IList(Of DTO.OrganizationDTO) Implements IBaseDAO.Query
        output.show("Query is invoke")
        Return Nothing
    End Function

    Function Insert(Of DTO.OrganizationDTO)(ByVal obj As DTO.OrganizationDTO) As Boolean Implements IBaseDAO.Insert
        output.show("Insert is invoke")

        Dim dr As DataRow = DataTables(TABLE_NAME).AddNew
        dr("name") = obj.name
        dr("code") = obj.code
        dr("status") = obj.status
        dr("parent_identify") = obj.parent_identify
        dr("short_name") = obj.short_name
        dr("description") = obj.description
        dr.Save

        Return True
    End Function

    Function Update(Of DTO.OrganizationDTO)(ByVal obj As DTO.OrganizationDTO) As Boolean Implements IBaseDAO.Update
        output.show("Update is invoke")
        Return True
    End Function

    Function Delete(Of DTO.OrganizationDTO)(ByVal obj As DTO.OrganizationDTO) As Boolean Implements IBaseDAO.Delete
        output.show("Delete is invoke")
        Return True
    End Function

End Class