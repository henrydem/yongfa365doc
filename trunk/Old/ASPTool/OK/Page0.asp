<%
'֧�ֶ���任��ASP��ҳ�� ˵���ļ�
'set Page1=New Page
'Page1.CurrentPage=Trim(Request("Page"))
'Page1.PageNum=20
'Page1.Url="pagetest.asp?cat=1&"
'Page1.Exec Sql, Conn
'
'set rs=Page1.PageRs


'for i=1 to rs.PageSize
'if rs.eof then exit for
'	�����б�
'rs.movenext
'next


'Page1.Temp="{N1} {N2} {N3} {N4} || ��:{N8}����¼ {N6}ҳ ��ǰΪ��{N5}ҳ ÿҳ{N7}��"
'Page1.show(1)
'response.write("<p><p><p>")
'Page1.Temp="[{N1}] [{N2}] [{N3}] [{N4}]"
'Page1.show(1)
'response.write("<p><p><p>")
'Page1.Temp="{N1} {N2} {L}{N}{L/}{N3}{N4}"
'Page1.show(2)
'response.write("<p><p><p>")
'Page1.Temp="{N1}{N2}{N9}{L}{N}{L/}{N10}{N3}{N4}"
'Page1.show(3)
'response.write("<p><p><p>")
'Page1.Temp="{N1}{N2}{N9}{L}{N}{L/}{N10}{N3}{N4} ��{N8}����¼ {N6}ҳ ��ǰΪ��{N5}ҳ ÿҳ{N7}��"
'Page1.show(4)
'response.write("<p><p><p>")
%>



<%
'֧�ֶ���任��ASP��ҳ��
Class Page
    Private CurrPage
    Private PageN
    Private UrlStr
    Private TempStr
    Private ErrInfo
    Private IsErr
    Private TotalRecord
    Private TotalPage
    Public PageRs
    
    Private TempA(11)
    Private TempB(8)
    '------------------------------------------------------------

    Private Sub Class_Initialize()
        CurrPage = 1'//Ĭ����ʾ��ǰҳΪ��һҳ
        PageN = 10'//Ĭ��ÿҳ��ʾ10������
        UrlStr = "#"
        TempStr = "{N1} {N2} {N3} {N4} || ��:{N8}����¼ {N6}ҳ ��ǰΪ��{N5}ҳ ÿҳ{N7}��"
        ErrInfo = "������ʾ:"
        IsErr = False
    End Sub


    Private Sub Class_Terminate()
        If IsObject(PageRs) Then
            PageRs.Close
            Set PageRs = Nothing
        End If
        Erase TempA
        Erase TempB
    End Sub

    '----------------------------------------------------------
    '//��ȡ��ǰҳ��

    Public Property Let CurrentPage(Val)
        CurrPage = Val
    End Property


    Public Property Get CurrentPage()
        CurrentPage = CurrPage
    End Property

    '//��ȡÿҳ��ʾ����

    Public Property Let PageNum(Val)
        PageN = Val
    End Property


    Public Property Get PageNum()
        PageNum = PageN
    End Property

    '//��ȡURL

    Public Property Let Url(Val)
        UrlStr = Val
    End Property


    Public Property Get Url()
        Url = UrlStr
    End Property

    '//��ȡģ��

    Public Property Let Temp(Val)
        TempStr = Val
    End Property


    Public Property Get Temp()
        Temp = TempStr
    End Property

    '------------------------------------------------------------
    
    Public Sub Exec(Sql, ConnObj)
        On Error Resume Next
        Set PageRs = Server.CreateObject("ADODB.RecordSet")
        PageRs.CursorLocation = 3 'ʹ�ÿͻ����α꣬����ʹЧ�����
        PageRs.PageSize = PageN '�����ҳ��¼��ÿҳ��ʾ��¼��
        PageRs.Open Sql, ConnObj, 1, 1
        If Err.Number<>0 Then
            Err.Clear
            PageRs.Close
            Set PageRs = Nothing
            ErrInfo = ErrInfo&"������򿪼�¼������..."
            IsErr = True
            Response.Write ErrInfo
            Response.End
        End If
        TotalRecord = PageRs.RecordCount'//���Ϊ0�أ�
        If TotalRecord>= 1 Then
            '----------------------------------------------------------------------------��ʼ
            TotalPage = PageRs.PageCount
            '//������ǰ����ҳ��,Ĭ�ϵ�Ϊ1�����Բ����������͵Ķ���Ϊ1
            If IsNumeric(CurrPage) Then
                CurrPage = CLng(CurrPage)
                If CurrPage<1 Then CurrPage = 1
                If CurrPage>TotalPage Then CurrPage = TotalPage
            Else
                '//Dim M:M="":IsNumeric(M)=True
                CurrPage = 1
            End If
            '---------------------------------------------------------------------------����
        Else
            TotalPage = 0
            CurrPage = 1
        End If
        '//
        PageRs.AbsolutePage = CurrPage 'absolutepage������ָ��ָ��ĳҳ��ͷ
        PageRs.PageSize = PageN
    End Sub


    Private Sub Init()
        'Private TempA(10)
        TempA(1) = "{N1}" '//��ҳ
        TempA(2) = "{N2}"'//��һҳ
        TempA(3) = "{N3}"'//��һҳ
        TempA(4) = "{N4}"'//βҳ
        TempA(5) = "{N5}"'//��ǰҳ��
        TempA(6) = "{N6}"'//ҳ������
        TempA(7) = "{N7}"'//ÿҳ����
        TempA(8) = "{N8}"'//��������
        TempA(9) = "{L}"'//ѭ����ǩ��ʼ
        TempA(10) = "{N}"'//ѭ���ڵ���ǩ��ҳ��
        TempA(11) = "{L/}"'//ѭ����ǩ����
        'Private TempB(8)
        TempB(1) = "��ҳ"
        TempB(2) = "��һҳ"
        TempB(3) = "��һҳ"
        TempB(4) = "βҳ"
        TempB(5) = CurrPage'//��ǰҳ��
        TempB(6) = TotalPage'//ҳ������
        TempB(7) = PageN'//ÿҳ����
        TempB(8) = TotalRecord'//��������
    End Sub


    Public Sub Show(Style)
        If IsErr = True Then
            Response.Write ErrInfo
            Exit Sub
        End If
        
        Call Init()
        Select Case Style
            Case 1
                Response.Write StyleA()
            Case 2
                Response.Write StyleB()
            Case 3
                Response.Write StyleC()
            Case 4
                Response.Write StyleD()
            Case Else
                ErrInfo = ErrInfo&"�����ڵ�ǰ��ʽ..."
                Response.Write ErrInfo
        End Select
    End Sub


    Public Function ShowStyle(Style)
        If IsErr = True Then
            ShowStyle = ErrInfo
            Exit Function
        End If
        
        Call Init()
        Select Case Style
            Case 1
                ShowStyle = StyleA()
            Case 2
                ShowStyle = StyleB()
            Case 3
                ShowStyle = StyleC()
            Case 4
                ShowStyle = StyleD()
            Case Else
                ErrInfo = ErrInfo&"�����ڵ�ǰ��ʽ..."
                ShowStyle = ErrInfo
        End Select
    End Function
    
    Private Function StyleA()
        '��ҳ ��һҳ ��һҳ βҳ  ��ҳΪ��1/20ҳ����20ҳ��ÿҳ10������������200��
        '//��ҳ������[��ҳ] [��ҳ] [��ҳ] [βҳ] [ҳ�Σ�4/5ҳ] [��86ƪ 20ƪ/ҳ] ת����_ ҳ
        '//��ǩ��{N1} {N2} {N3} {N4} || ��:{N8}����¼ {N6}ҳ ��ǰΪ��{N5}ҳ ÿҳ{N7}��
        If IsEmpty(TempStr) Then
            ErrInfo = ErrInfo&"ģ��Ϊ��..."
            StyleB = ErrInfo
            Exit Function
        End If
        Dim M
        If TotalPage>1 Then
            If CurrPage>1 Then
                M = "<a href='"&UrlStr&"Page=1'>"&"��ҳ"&"</a>"
                TempStr = Replace(TempStr, "{N1}", M)
                M = "<a href='"&UrlStr&"Page="&CurrPage -1&"'>"&"��һҳ"&"</a>"
                TempStr = Replace(TempStr, "{N2}", M)
                If CurrPage<TotalPage Then
                    M = "<a href='"&UrlStr&"Page="&CurrPage+1&"'>"&"��һҳ"&"</a>"
                    TempStr = Replace(TempStr, "{N3}", M)
                    M = "<a href='"&UrlStr&"Page="&TotalPage&"'>"&"βҳ"&"</a>"
                    TempStr = Replace(TempStr, "{N4}", M)
                Else
                    TempStr = Replace(TempStr, "{N3}", "��һҳ")
                    TempStr = Replace(TempStr, "{N4}", "βҳ")
                End If
            Else
                TempStr = Replace(TempStr, "{N1}", "��ҳ")
                TempStr = Replace(TempStr, "{N2}", "��һҳ")
                M = "<a href='"&UrlStr&"Page="&CurrPage+1&"'>"&"��һҳ"&"</a>"
                TempStr = Replace(TempStr, "{N3}", M)
                M = "<a href='"&UrlStr&"Page="&TotalPage&"'>"&"βҳ"&"</a>"
                TempStr = Replace(TempStr, "{N4}", M)
            End If
        Else
            TempStr = Replace(TempStr, "{N1}", "��ҳ")
            TempStr = Replace(TempStr, "{N2}", "��һҳ")
            TempStr = Replace(TempStr, "{N3}", "��һҳ")
            TempStr = Replace(TempStr, "{N4}", "βҳ")
        End If
        T = TempStr
        T = Replace(T, "{N8}", TotalRecord)
        T = Replace(T, "{N6}", TotalPage)
        T = Replace(T, "{N5}", CurrPage)
        T = Replace(T, "{N7}", PageN)
        TempStr = T
        StyleA = TempStr
    End Function
    
    Private Function StyleB()
        '��ҳ |< 1 2 3 4 5 6 7 >| βҳ
        '//��ǩ:{N1} {N2} {L}{N}{L/}{N3}{N4}
        If IsEmpty(TempStr) Then
            ErrInfo = ErrInfo&"ģ��Ϊ��..."
            StyleB = ErrInfo
            Exit Function
        End If
        Dim ForceNum, BackNum'//��ǰҳ��ǰ��ͺ�����ʾ����
        ForceNum = 5
        BackNum = 4
        Dim M
        '//��ҳ
        M = "<a href='"&UrlStr&"Page=1'>"&TempB(1)&"</a>"
        TempStr = Replace(TempStr, "{N1}", M)
        '//βҳ
        M = "<a href='"&UrlStr&"Page="&TempB(6)&"'>"&TempB(4)&"</a>"
        TempStr = Replace(TempStr, "{N4}", M)
        '//ǰһҳ
        M = "|<"
        If CurrPage -1>= 1 Then
            M = "<a href='"&UrlStr&"Page="&CurrPage -1&"'>"&"|<"&"</a>"
        End If
        TempStr = Replace(TempStr, "{N2}", M)
        '//��һҳ
        M = ">|"
        If CurrPage+1<= TotalPage Then
            M = "<a href='"&UrlStr&"Page="&CurrPage+1&"'>"&">|"&"</a>"
        End If
        TempStr = Replace(TempStr, "{N3}", M)
        '//ȡ��ѭ����ǩ
        Dim N1, N2, N3, N4, N5, N6
        If InStr(TempStr, "{L}")>0 Then
            N1 = InStr(TempStr, "{L}")
        End If
        If InStr(TempStr, "{L/}")>0 Then
            N2 = InStr(TempStr, "{L/}")
        End If
        If N2<= N1 Then
            ErrInfo = ErrInfo&"ѭ����ǩ����..."
            StyleB = ErrInfo
            Exit Function
        End If
        N3 = Mid(TempStr, N1, N2 - N1 + 4)'//�������{L}{L/}ѭ����ǩ��ģ��
        N4 = Replace(N3, "{L}", "")'//���治����{L}{L/}ѭ����ǩ��ģ��
        N4 = Replace(N4, "{L/}", "")
        '//ҳ���б�
        Dim FirstPageNum, LastPageNum
        If CurrPage - ForceNum<= 1 Then
            FirstPageNum = 1
            PageList = ""
        Else
            FirstPageNum = CurrPage - ForceNum
            PageList = "... ..."
        End If
        If CurrPage+BackNum>= TotalPage Then
            LastPageNum = TotalPage
            PageList_2 = ""
        Else
            LastPageNum = CurrPage+BackNum
            PageList_2 = "... ..."
        End If
        Dim I
        For I = FirstPageNum To LastPageNum
            If I = CurrPage*1 Then
                N5 = Replace(N4, "{N}", "<b>"&I&"</b>")
                N6 = N6&N5
            Else
                M = "<a href='"&UrlStr&"Page="&I&"'>"&I&"</a>"
                N5 = Replace(N4, "{N}", M)
                N6 = N6&N5
            End If
        Next
        TempStr = Replace(TempStr, N3, N6)
        StyleB = TempStr
    End Function
    
    Private Function StyleC()
        '��ҳ |< |<< 1 2 3 4 5 6 7 >>| >| βҳ
        '//�˷����StyleB�Ļ������޸ģ�����������ǩ��{N9}��10ҳ {N10}��10ҳ
        '//��ǩ:{N1}{N2}{N9}{L}{N}{L/}{N10}{N3}{N4}
        Dim T
        T = StyleB()
        '//ǰʮҳ
        M = "|<<"
        If CurrPage -10>= 1 Then
            M = "<a href='"&UrlStr&"Page="&CurrPage -10&"'>"&"|<<"&"</a>"
        End If
        T = Replace(T, "{N9}", M)
        M = ">>|"
        If CurrPage+10<= TotalPage Then
            M = "<a href='"&UrlStr&"Page="&CurrPage+10&"'>"&">>|"&"</a>"
        End If
        T = Replace(T, "{N10}", M)
        StyleC = T
    End Function
    
    Private Function StyleD()
        '//�˷����StyleC�Ļ������޸�
        '//��ҳ |< |<< 1 2 3 4 5 6 7 >>| >| βҳ����{N8}����¼ {N6}ҳ ��ǰΪ��{N5}ҳ ÿҳ{N7}��
        '//��ǩ:{N1}{N2}{N9}{L}{N}{L/}{N10}{N3}{N4} ��{N8}����¼ {N6}ҳ ��ǰΪ��{N5}ҳ ÿҳ{N7}��
        Dim T
        T = StyleC()
        T = Replace(T, "{N8}", TotalRecord)
        T = Replace(T, "{N6}", TotalPage)
        T = Replace(T, "{N5}", CurrPage)
        T = Replace(T, "{N7}", PageN)
        StyleD = T
    End Function
    
End Class
%>