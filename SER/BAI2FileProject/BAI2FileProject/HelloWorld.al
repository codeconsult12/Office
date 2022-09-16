// Welcome to your new AL extension.
// Remember that object names and IDs should be unique across all extensions.
// AL snippets start with t*, like tpageext = give them a try and happy coding!

xmlPort 50100 XMLPortBai2
{
    Caption = 'Data Import. Bia2';
    Direction = Import;
    Format = VariableText;
    Permissions = TableData "Data Exch. Field" = rimd;
    TextEncoding = WINDOWS;
    UseRequestPage = false;

    schema
    {
        textelement(root)
        {
            MinOccurs = Zero;
            tableelement("Data Exch."; "Data Exch.")
            {
                AutoSave = false;
                XmlName = 'DataExchDocument';
                textelement(col1)
                {
                    MaxOccurs = Once;
                    MinOccurs = Zero;
                    XmlName = 'col1';

                    trigger OnAfterAssignVariable()
                    begin
                        ColumnNo := 1;
                        checkLineType;
                        InsertColumn(ColumnNo, col1);
                    end;
                }
                textelement(colx)
                {
                    MinOccurs = Zero;
                    Unbound = true;
                    XmlName = 'colx';

                    trigger OnAfterAssignVariable()
                    begin
                        ColumnNo += 1;
                        InsertColumn(ColumnNo, colx);
                    end;
                }

                trigger OnAfterInitRecord()
                begin
                    FileLineNo += 1;
                end;

                trigger OnBeforeInsertRecord()
                begin
                    ValidateHeaderTag;
                end;
            }
        }
    }

    requestpage
    {

        layout
        {
        }

        actions
        {
        }
    }

    trigger OnPostXmlPort()
    begin
        message('onPostXMLPort');
        if (not LastLineIsFooter and SkipLine) or HeaderWarning then
            Error(LastLineIsHeaderErr);
    end;

    trigger OnPreXmlPort()
    begin
        Message('on Init');
        InitializeGlobals;
    end;

    var
        DataExchField: Record "Data Exch. Field";
        DataExchEntryNo: Integer;
        ImportedLineNo: Integer;
        FileLineNo: Integer;
        HeaderLines: Integer;
        HeaderLineCount: Integer;
        ColumnNo: Integer;
        HeaderTag: Text;
        FooterTag: Text;
        SkipLine: Boolean;
        LastLineIsFooter: Boolean;
        HeaderWarning: Boolean;
        LineType: Option Unknown,Header,Footer,Data,FileHeader,GroupHeader,AccountIdentifier,TransactionDetail,AccountTrailer,GroupTrailer,FileTrailer,HeaderDate,HeaderAccount,FooterAccount,FooterData,Continuation;
        CurrentLineType: Option;
        FullHeaderLine: Text;
        LastLineIsHeaderErr: Label 'The imported file contains unexpected formatting. One or more lines may be missing in the file.';
        WrongHeaderErr: Label 'The imported file contains unexpected formatting. One or more headers are incorrect.';
        DataExchLineDefCode: Code[20];

    local procedure InitializeGlobals()
    var
        DataExchDef: Record "Data Exch. Def";
    begin
        DataExchEntryNo := "Data Exch.".GetRangeMin("Entry No.");
        "Data Exch.".Get(DataExchEntryNo);
        DataExchLineDefCode := "Data Exch."."Data Exch. Line Def Code";
        DataExchDef.Get("Data Exch."."Data Exch. Def Code");
        HeaderLines := DataExchDef."Header Lines";
        ImportedLineNo := 0;
        FileLineNo := 0;
        HeaderTag := DataExchDef."Header Tag";
        FooterTag := DataExchDef."Footer Tag";
        HeaderLineCount := 0;
        CurrentLineType := LineType::Unknown;
        FullHeaderLine := '';
        currXMLport.FieldSeparator(DataExchDef.ColumnSeparatorChar);
        case DataExchDef."File Encoding" of
            DataExchDef."File Encoding"::"MS-DOS":
                currXMLport.TextEncoding(TEXTENCODING::MSDos);
            DataExchDef."File Encoding"::"UTF-8":
                currXMLport.TextEncoding(TEXTENCODING::UTF8);
            DataExchDef."File Encoding"::"UTF-16":
                currXMLport.TextEncoding(TEXTENCODING::UTF16);
            DataExchDef."File Encoding"::WINDOWS:
                currXMLport.TextEncoding(TEXTENCODING::Windows);
        end;
    end;

    // local procedure CheckLineType()
    // begin
    //     IdentifyLineType;
    //     ValidateNonDataLine;
    //     TrackNonDataLines;
    //     SkipLine := CurrentLineType <> LineType::Data;

    //     if not SkipLine then begin
    //         HeaderLineCount := 0;
    //         ImportedLineNo += 1;
    //     end;
    // end;

    // local procedure IdentifyLineType()
    // begin
    //     case true of
    //         FileLineNo <= HeaderLines:
    //             CurrentLineType := LineType::Header;
    //         (HeaderTag <> '') and (StrLen(col1) <= HeaderTagLength) and (StrPos(HeaderTag, col1) = 1):
    //             CurrentLineType := LineType::Header;
    //         (FooterTag <> '') and (StrLen(col1) <= FooterTagLength) and (StrPos(FooterTag, col1) = 1):
    //             CurrentLineType := LineType::Footer;
    //         else
    //             CurrentLineType := LineType::Data;
    //     end;
    // end;

    local procedure ValidateNonDataLine()
    begin
        if CurrentLineType = LineType::Header then begin
            if (HeaderTag <> '') and (StrLen(col1) <= HeaderTagLength) and (StrPos(HeaderTag, col1) = 0) then
                Error(WrongHeaderErr);
        end;
    end;

    local procedure TrackNonDataLines()
    begin
        case CurrentLineType of
            LineType::Header:
                begin
                    HeaderLineCount += 1;
                    if not HeaderWarning and (HeaderLines > 0) and (HeaderLineCount > HeaderLines) then
                        HeaderWarning := true;
                end;
            LineType::Data:
                if (HeaderLines > 0) and (HeaderLineCount > 0) and (HeaderLineCount < HeaderLines) then
                    HeaderWarning := true;
            LineType::Footer:
                LastLineIsFooter := true;
        end;
    end;

    local procedure HeaderTagLength(): Integer
    var
        DataExchDef: Record "Data Exch. Def";
    begin
        exit(GetFieldLength(DATABASE::"Data Exch. Def", DataExchDef.FieldNo("Header Tag")));
    end;

    local procedure FooterTagLength(): Integer
    var
        DataExchDef: Record "Data Exch. Def";
    begin
        exit(GetFieldLength(DATABASE::"Data Exch. Def", DataExchDef.FieldNo("Footer Tag")));
    end;

    local procedure GetFieldLength(TableNo: Integer; FieldNo: Integer): Integer
    var
        RecRef: RecordRef;
        FieldRef: FieldRef;
    begin
        RecRef.Open(TableNo);
        FieldRef := RecRef.Field(FieldNo);
        exit(FieldRef.Length);
    end;

    // local procedure InsertColumn(columnNumber: Integer; var columnValue: Text)
    // var
    //     savedColumnValue: Text;
    // begin
    //     savedColumnValue := columnValue;
    //     columnValue := '';
    //     if SkipLine then begin
    //         if (CurrentLineType = LineType::Header) and (HeaderTag <> '') then
    //             FullHeaderLine += savedColumnValue + ';';
    //         exit;
    //     end;
    //     if savedColumnValue <> '' then begin
    //         DataExchField.Init();
    //         DataExchField.Validate("Data Exch. No.", DataExchEntryNo);
    //         DataExchField.Validate("Line No.", ImportedLineNo);
    //         DataExchField.Validate("Column No.", columnNumber);
    //         DataExchField.Validate(Value, CopyStr(savedColumnValue, 1, MaxStrLen(DataExchField.Value)));
    //         DataExchField.Validate("Data Exch. Line Def Code", DataExchLineDefCode);
    //         DataExchField.Insert(true);
    //     end;
    // end;

    local procedure ValidateHeaderTag()
    begin
        if SkipLine and (CurrentLineType = LineType::Header) and (HeaderTag <> '') then
            if StrPos(FullHeaderLine, HeaderTag) = 0 then begin
                Error(WrongHeaderErr);
                Message('Header Error');
            end;


    end;





    local procedure IdentifyLineType()
    begin
        case true of
            col1 = '02':
                CurrentLineType := LineType::HeaderDate;
            col1 = '03':
                CurrentLineType := LineType::HeaderAccount;
            col1 = '16':
                CurrentLineType := LineType::Data;
            col1 = '49':
                CurrentLineType := LineType::FooterAccount;
            col1 = '98':
                CurrentLineType := LineType::FooterData;
            col1 = '99':
                CurrentLineType := LineType::Footer;
            col1 = '88':
                CurrentLineType := LineType::Continuation;


        //             CurrentLineType := LineType::Header;
        //         (FooterTag <> '') and (StrLen(col1) <= FooterTagLength) and (StrPos(FooterTag, col1) = 1):
        //             CurrentLineType := LineType::Footer;
        //         else
        //             CurrentLineType := LineType::Data;
        //     end;


        end;

    end;

    local procedure checkLineType()
    begin


        IdentifyLineType;
        Message('Current Line Type=' + Format(CurrentLineType));
        SkipLine := CurrentLineType <> LineType::Data;
        TrackNonDataLines();
        if not SkipLine then begin
            ImportedLineNo += 1;
            Message('Line Number is = ' + Format(ImportedLineNo));

        end;
    end;

    local procedure InsertColumnNew(columnNumber: Integer; var columnValue: Text)
    var
        savedColumnValue: Text;
    begin
        savedColumnValue := columnValue;
        columnValue := '';
        if SkipLine then begin
            if (CurrentLineType = LineType::Header) and (HeaderTag <> '') then
                FullHeaderLine += savedColumnValue + ';';
            exit;
        end;
        if savedColumnValue <> '' then begin
            DataExchField.Init();
            DataExchField.Validate("Data Exch. No.", DataExchEntryNo);
            DataExchField.Validate("Line No.", ImportedLineNo);
            DataExchField.Validate("Column No.", columnNumber);
            DataExchField.Validate(Value, CopyStr(savedColumnValue, 1, MaxStrLen(DataExchField.Value)));
            DataExchField.Validate("Data Exch. Line Def Code", DataExchLineDefCode);
            DataExchField.Insert(true);
            Message('Line No.= ' + Format(ImportedLineNo) + ' Column No. = ' + Format(columnNumber) + ' Value = ' + CopyStr(savedColumnValue, 1, MaxStrLen(DataExchField.Value)) + ' Def Code= ' + DataExchLineDefCode);
        end;
    end;

    local procedure InsertColumn(columnNumber: Integer; var columnValue: Text)
    var
        BankAccountIncorrectErr: Text;
        BankAccount: Record "Bank Account";
        TransactionCode: text;
        DescriptionPos: Integer;
        TransactionCodeInt: Integer;
        savedColumnValue: Text;
        DecimalText: text;
        IntegerText: Text;
        FundsType: Text[1];
        TransactionDate: Text;
        Int: Integer;
        factor: Integer;
        savedColumnValueInt: Integer;
        Dec: Decimal;
    begin
        BankAccountIncorrectErr := 'Acccount Doesnot exist';
        savedColumnValue := columnValue;
        columnValue := '';
        if SkipLine then begin
            if (CurrentLineType = LineType::HeaderDate) and (columnNumber = 5) then // Transaction Date
                if (CurrentLineType = LineType::HeaderAccount) and (columnNumber = 2) then // Bank Account No.
                    if savedColumnValue <> BankAccount."Bank Account No." then
                        Error(BankAccountIncorrectErr, savedColumnValue, BankAccount."Bank Account No.", FileLineNo, columnNumber);
            exit;
        end;
        case true of
            columnNumber = 1:
                InsertColumnNew(100, TransactionDate);
            columnNumber = 2:
                begin // Transaction Code
                    TransactionCode := savedColumnValue;
                    Evaluate(TransactionCodeInt, TransactionCode);
                    InsertColumnNew(columnNumber, savedColumnValue);
                    Message('Transaction Code=' + TransactionCode);
                end;
            columnNumber = 3:
                begin // Amount
                    DecimalText := CopyStr(savedColumnValue, StrLen(savedColumnValue) - 1); // Decimal part, 2 decimals
                    IntegerText := CopyStr(savedColumnValue, 1, StrLen(savedColumnValue) - 2); // integer part
                    Message('Actual Amount' + DecimalText + ' ' + IntegerText);
                    if IntegerText <> '' then
                        Evaluate(Int, IntegerText);
                    if DecimalText <> '' then
                        Evaluate(Dec, DecimalText);
                    factor := 1;
                    if TransactionCodeInt > 400 then
                        factor := -1;
                    savedColumnValue := FORMAT((Int + (Dec / 100)) * factor);
                    InsertColumnNew(columnNumber, savedColumnValue);
                    Message('Amount' + FORMAT((Int + (Dec / 100)) * factor));
                end;
            columnNumber = 4: // funds type
                begin
                    FundsType := savedColumnValue;
                    case FundsType of
                        '', 'e', '1', '2':
                            DescriptionPos := 7;
                        'S':
                            DescriptionPos := 10;
                        'V':
                            DescriptionPos := 9;

                    end;
                    Message('Funds type:' + FundsType);
                end;
            (columnNumber = 5) and (FundsType = 'D'):
                begin
                    Evaluate(savedColumnValueInt, savedColumnValue);
                    DescriptionPos := savedColumnValueInt * 2;
                    Message('Description= %2\', DescriptionPos);
                end;
            (columnNumber = 6) and (TransactionCode IN ['474', '1475', '395']): // codes for Check Paid
                InsertColumnNew(columnNumber, savedColumnValue);
            columnNumber = DescriptionPos: //Descripton Position is always greater than 5
                begin
                    savedColumnValue := Delchr(savedColumnValue, '=', '/'); // when the line has no description text, it ends with "/"
                    InsertColumnNew(7, savedColumnValue);
                end;
        end;
    end;


}
