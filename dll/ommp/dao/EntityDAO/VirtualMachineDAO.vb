Imports ommp.dto
Imports Foxtable

Namespace dao
    Public Class VirtualMachineDAO : Inherits BaseDAO

        Public Sub New()
            ' 构造函数，默认为空
        End Sub

        '添加一台虚拟机
        '
        Public Function Insert(ByVal obj As VirtualMachine) As Boolean

            Return Nothing
        End Function

        '修改一台虚拟机
        '
        Public Function Update(ByVal obj As VirtualMachine) As Boolean

            Return Nothing
        End Function

        '修改一台虚拟机
        '
        Public Function Delete(ByVal id As Integer) As Boolean

            Return Nothing
        End Function

        '查询一台虚拟机
        '
        Public Function FindObject(ByVal id As Integer) As VirtualMachine

            Return Nothing
        End Function

        '查询虚拟机列表
        '
        Public Function FindList(ByVal filter As String, ByVal sort As String) As IList(Of VirtualMachine)

            Return Nothing
        End Function
    End Class
End Namespace
