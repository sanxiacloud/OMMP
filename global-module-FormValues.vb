'全局窗口跳转参数,格式为 (窗口名_键名,键值)
Public FormParams As New Dictionary(Of String,Dictionary(Of String,String))

Function SetFormParam(formName As String, key As String, value As String)
    Dim dic As Dictionary(Of String, String)
    If FormParams.ContainsKey(formName)
        dic = FormParams(formName)
    Else
        dic = New Dictionary(Of String, String)
        FormParams.Add(formName, dic)
    End IF
    If dic.ContainsKey(key)
        dic(key) = value
    Else
        dic.Add(key,value)    
    End If
End Function

Function GetFormParam(formName As String, key As String) As String
    Dim dic As Dictionary(Of String, String)
    If FormParams.ContainsKey(formName)
        dic = FormParams(formName)
    Else
        dic = New Dictionary(Of String, String)
        FormParams.Add(formName, dic)
    End IF
    If dic.ContainsKey(key)
        Return dic(key)
    Else
        Return Nothing    
    End If
End Function

Function ClearFormParams(fornName As String)
    If FormParams.ContainsKey(fornName)
        FormParams(fornName).Clear()
    End If
End Function

'全局窗口回传结果,格式为 (窗口名_键名,键值)
Public FormResults As New Dictionary(Of String,Dictionary(Of String,String))

Function SetFormResult(formName As String, key As String, value As String)
    Dim dic As Dictionary(Of String, String)
    If FormResults.ContainsKey(formName)
        dic = FormResults(formName)
    Else
        dic = New Dictionary(Of String, String)
        FormResults.Add(formName, dic)
    End IF
    If dic.ContainsKey(key)
        dic(key) = value
    Else
        dic.Add(key,value)    
    End If
End Function

Function GetFormResult(formName As String, key As String) As String
    Dim dic As Dictionary(Of String, String)
    If FormResults.ContainsKey(formName)
        dic = FormResults(formName)
    Else
        dic = New Dictionary(Of String, String)
        FormResults.Add(formName, dic)
    End IF
    If dic.ContainsKey(key)
        Return dic(key)
    Else
        Return Nothing    
    End If
End Function

Function ClearFormResults(fornName As String)
    If FormResults.ContainsKey(fornName)
        FormResults(fornName).Clear()
    End If
End Function

'全局窗口局部变量,格式为 (窗口名_键名,键值)
Public FormVariables As New Dictionary(Of String,Dictionary(Of String,String))

Function SetFormVariable(formName As String, key As String, value As String)
    Dim dic As Dictionary(Of String, String)
    If FormVariables.ContainsKey(formName)
        dic = FormVariables(formName)
    Else
        dic = New Dictionary(Of String, String)
        FormVariables.Add(formName, dic)
    End IF
    If dic.ContainsKey(key)
        dic(key) = value
    Else
        dic.Add(key,value)    
    End If
End Function

Function GetFormVariable(formName As String, key As String) As String
    Dim dic As Dictionary(Of String, String)
    If FormVariables.ContainsKey(formName)
        dic = FormVariables(formName)
    Else
        dic = New Dictionary(Of String, String)
        FormVariables.Add(formName, dic)
    End IF
    If dic.ContainsKey(key)
        Return dic(key)
    Else
        Return Nothing    
    End If
End Function

Function ClearFormVariables(fornName As String)
    If FormVariables.ContainsKey(fornName)
        FormParams(fornName).Clear()
    End If
End Function