using System;
using System.Collections.Generic;

public class Response<T>
{
    public T Result { get; set; } 
    public string Message { get; set; }
    public bool Ok { get; set; }
    public List<string> Errors { get; set; }


    //Methods
    public void ok(bool Ok, T Result)
    {
        this.Ok = Ok;
        this.Message = "ok";
        this.Result = Result;
        this.Errors = null;
    }

    public void ok(bool Ok, T Result, String Message)
    {
        this.Ok = Ok;
        this.Result = Result;
        this.Errors = null;
        this.Message = Message;
    }

    private void ok(bool Ok, List<String> Errors, String Message)
    {
        this.Ok = Ok;
        this.Errors = Errors;
        this.Message = Message;
        this.Result = default(T);
    }
}