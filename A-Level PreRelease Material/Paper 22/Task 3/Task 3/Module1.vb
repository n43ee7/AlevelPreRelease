Module Module1
    'Task 3
    ' Credits to N43EE7 >> github.com/n43ee7

    Dim Contentline As String
    Dim Linenum As Integer = 0

    Sub Main()

        init5()
        Menu()
        Console.ReadKey()

    End Sub
    Sub init5()
        Console.BackgroundColor = ConsoleColor.Blue
        Console.ForegroundColor = ConsoleColor.White
        For x = 1 To 5
            Console.Beep()
            System.Threading.Thread.Sleep(50)
        Next
    End Sub
    Sub Menu()
        Console.WriteLine("#################################################")
        Console.WriteLine("        Welcome to Cyprus National Library")
        Console.WriteLine("#################################################")
        Console.WriteLine(vbTab)
        Console.WriteLine("Please choose from the following options:")
        Console.WriteLine("###")
        Console.WriteLine("1) Adding a new record")
        Console.WriteLine("2) Searching an existing record")
        Console.WriteLine("3) Viewing Current Records")
        Console.WriteLine("4) Deleting an existing record")
        Console.WriteLine("5) Exiting console")
        Dim menuoption As Integer
        Dim Sinput As String = ""
        Dim flag As Boolean

        menuoption = Console.ReadLine()

        Select Case menuoption
            Case 1
                Sinput = Console.ReadLine()
                Addrec(Sinput)
            Case 2
                Console.Clear()
                Console.Write("[!] Enter the Object to be Searched ")
                Sinput = Console.ReadLine()
                If Searchrec(Sinput) = False Then
                    Console.WriteLine("[!] Searched Entity '" & Sinput & "' NOT found!")
                Else
                    Console.WriteLine("[!] Searched Entity '" & Sinput & "' found on line number " & Linenum)
                    Console.WriteLine(vbTab)
                End If
                System.Threading.Thread.Sleep(1000)
                Menu()
            Case 3
                DisplayRecords()
            Case 4
                Console.Clear()
                Console.Write("[!] Enter the Object to be Deleted ")
                Sinput = Console.ReadLine()
                DeleteRecord(Sinput)
                Menu()
            Case 5
                Console.Clear()
                Console.WriteLine("[!] Exiting...")
                System.Threading.Thread.Sleep(700)
                End
        End Select
    End Sub
    Sub DeleteRecord(ByRef tbd As String)
        Dim internalflag As Boolean = False
        Dim Cache As String
        Dim TCache As String

        If Searchrec(tbd) = False Then
            Console.WriteLine("[!] Item not located")
            System.Threading.Thread.Sleep(800)
        Else
            FileOpen(1, "Records.txt", OpenMode.Append)
            Do While Internalflag = False And Not EOF(1)
                Cache = LineInput(1)
                TCache = TCache + "@" + Cache
            Loop
            Console.WriteLine(TCache)
            FileClose()
        End If

    End Sub
    Sub DisplayRecords()
        FileOpen(1, "Records.txt", OpenMode.Input)

        FileClose()
    End Sub
    Sub Addrec(ByVal Sinput As String)
        FileOpen(1, "Records.txt", OpenMode.Append) 'OpenMode.Output For the case the file is not made(Default the location will be in the bin\Debug folder of the program)

        FileClose()
    End Sub
    Function Searchrec(ByRef Sinput As String)
        Linenum = 0
        FileOpen(1, "Records.txt", OpenMode.Input)
        Dim Internalflag As Boolean = False
        Linenum = 0
        Do While Internalflag = False And Not EOF(1)
            Contentline = LineInput(1)
            Linenum = Linenum + 1
            If Contentline = Sinput Then
                Internalflag = True
            End If
        Loop

        FileClose()
        Return Internalflag
    End Function
End Module
