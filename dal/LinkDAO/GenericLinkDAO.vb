﻿Imports System.Reflection
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
            Dim str As String() = tableName.Split(S_LNK)(1).Split(S_TO)
            leftColumnName = str(0).ToLower() & C__IDENTIFY
            rightColumnName = str(1).ToLower() & C__IDENTIFY
        End Sub

        Public Function ListByLeft(id As Integer) As IList(Of T)
            Return FindList(Of T)(String.Format("{0}={1}", leftColumnName, id), C__IDENTIFY)
        End Function

        Public Function ListByRight(id As Integer) As IList(Of T)
            Return FindList(Of T)(String.Format("{0}={1}", rightColumnName, id), C__IDENTIFY)
        End Function

        Public Function Link(ByVal leftId As Integer, ByVal rightId As Integer) As Boolean
            Dim item As New T()
            Dim table_name As String = item.GetType().Name
            Dim result As Boolean = False

            Try
                Dim dr As DataRow = DataTables(table_name).AddNew()

                For Each info As PropertyInfo In item.GetType().GetProperties()
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

                result = True
            Catch ex As Exception
                log.Error(table_name & "(DAO) -> Link ")
                log.Error(ex.Message)
                log.Error(ex.StackTrace)
            End Try

            Return result
        End Function

        Public Function UnLink(ByVal leftId As Integer, ByVal rightId As Integer) As Boolean
            Dim obj As New T()
            Dim result As Boolean = False

            Try
                Dim filter As String = String.Format("{0}={1}", leftColumnName, leftId)
                filter = filter & " AND " & String.Format("{0}={1}", leftColumnName, rightId)

                Dim dr As DataRow = DataTables(tableName).Find(filter)

                dr(C__ISDELETED) = True
                dr.Load()

                result = True
            Catch ex As Exception
                log.Error(obj.GetType().Name & "(DAO) -> UnLink ")
                log.Error(ex.Message)
                log.Error(ex.StackTrace)
            End Try

            Return result
        End Function

    End Class

End Namespace