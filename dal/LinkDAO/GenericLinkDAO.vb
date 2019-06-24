Imports System.Reflection
Imports Foxtable
Imports log4net

Namespace dal.dao
    Public Class GenericLinkDAO(Of T As New)
        Inherits BaseDAO

        Private Shared ReadOnly log As ILog = LogManager.GetLogger(Reflection.MethodBase.GetCurrentMethod().DeclaringType)

        Private ReadOnly tableName As String
        Private ReadOnly leftColumnName As String
        Private ReadOnly rightColumnName As String

        Sub New()
            ' LnkApplicationSolutionToFunctionalCI 从类名称中抽取 Lnk 与 To 分隔后的
            tableName = GetType(T).Name
			Dim str As String() = tableName.Replace(S_LNK, "").Replace(S_TO, ",").Split(",")
			leftColumnName = str(0).ToLower() & C__IDENTIFY.ToLower()
            rightColumnName = str(1).ToLower() & C__IDENTIFY.ToLower()
        End Sub

		Public Function ListByLeft(id As Integer) As IList(Of T)
            Return FindList(Of T)(String.Format("{0}={1}", leftColumnName, id), C__IDENTIFY)
        End Function

        Public Function ListByRight(id As Integer) As IList(Of T)
            Return FindList(Of T)(String.Format("{0}={1}", rightColumnName, id), C__IDENTIFY)
        End Function

		Public Function Link(ByVal leftId As Integer, ByVal rightId As Integer) As Boolean
			Dim type As Type = GetType(T)
			Dim table_name As String = type.Name
			Dim result As Boolean = False

			Try
				Dim filter As String = String.Format("{0}=False AND {1}={2} AND {3}={4}", C__ISDELETED, leftColumnName, leftId, rightColumnName, rightId)
				Dim dr As DataRow = DataTables(tableName).Find(filter)

				If dr Is Nothing Then

					dr = DataTables(table_name).AddNew()

					For Each info As PropertyInfo In type.GetProperties()
						' 默认存在对应的列 
						'DataTables(table_name).DataCols.Contains(leftColumnName)
						'DataTables(table_name).DataCols.Contains(rightColumnName)
						If info.Name.Equals(leftColumnName) Then
							dr(leftColumnName) = leftId
						ElseIf info.Name.Equals(rightColumnName) Then
							dr(rightColumnName) = rightId
						End If
					Next

					dr(C__ISDELETED) = False ' 默认设置为 False
					dr.Load()
				Else
					log.Warn(String.Format("{0}(DAO) -> UnLink ", type.Name))
					log.Warn(String.Format("\tLink '{0}'<->'{1}' already existed! Abort.", leftId, rightId))
				End If

				result = True
			Catch ex As Exception
				log.Error(table_name & "(DAO) -> Link ")
				log.Error(ex.Message)
				log.Error(ex.StackTrace)
			End Try

			Return result
		End Function

		Public Function UnLink(ByVal leftId As Integer, ByVal rightId As Integer) As Boolean
			Dim type As Type = GetType(T)
			Dim result As Boolean = False

			Try
				Dim filter As String = String.Format("{0}=False AND {1}={2} AND {3}={4}", C__ISDELETED, leftColumnName, leftId, rightColumnName, rightId)
				Dim dr As DataRow = DataTables(tableName).Find(filter)

				If dr Is Nothing Then
					log.Warn(String.Format("{0}(DAO) -> UnLink ", type.Name))
					log.Warn(String.Format("\tLink '{0}'<->'{1}' not existed!", leftId, rightId))
				Else
					dr(C__ISDELETED) = True
					dr.Load()
				End If

				result = True
			Catch ex As Exception
				log.Error(type.Name & "(DAO) -> UnLink ")
				log.Error(ex.Message)
				log.Error(ex.StackTrace)
			End Try

			Return result
		End Function

	End Class

End Namespace
