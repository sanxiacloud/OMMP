Imports Foxtable
Imports System.Reflection
Imports log4net

Namespace dal.dao

    Public Class GenericSimpleEntityDAO(Of T As New)
        Inherits BaseDAO

        Private Shared ReadOnly log As ILog = LogManager.GetLogger(Reflection.MethodBase.GetCurrentMethod().DeclaringType)

        Function Find(id As Integer) As T
            Return FindObject(Of T)(id)
        End Function

        Public Function List(Optional filter As String = "", Optional sort As String = Nothing) As IList(Of T)
            Dim lists As IList(Of T) = New List(Of T)()
            Dim item As New T()
            Dim table_name As String = item.GetType().Name
            Dim theFilter As String = String.Format("{0} AND {1}=False", filter, C__ISDELETED)
            Output.Show(String.Format("theFilter = [{0}]", theFilter))
            Try
                Dim drs As List(Of DataRow)

                If sort IsNot Nothing Then
                    drs = DataTables(table_name).Select(theFilter, sort)
                Else
                    drs = DataTables(table_name).Select(theFilter)
                End If

                For Each dr As DataRow In drs
                    For Each info As PropertyInfo In item.GetType().GetProperties()
                        info.SetValue(item, dr(info.Name), Nothing)
                        Output.Show(String.Format("{0} = {1}", info.Name, dr(info.Name)))
                    Next

                    lists.Add(item)
                Next
                Output.Show(String.Format("lists.count = {0}", lists.Count))
                Output.Show(lists(0).ToString())
                Output.Show(lists(10).ToString())
            Catch ex As Exception
                log.Error(table_name & "(DAO) -> FindList ")
                log.Error(ex.Message)
                log.Error(ex.StackTrace)
            End Try

            Return lists
        End Function

        Public Function Insert(o As T) As Integer
            Return InsertObject(o)
        End Function

        Public Function Update(o As T) As Boolean
            Return UpdateObject(o)
        End Function

        Public Function Delete(id As Integer) As Boolean
            Return DeleteObject(Of T)(id)
        End Function

    End Class
End Namespace
