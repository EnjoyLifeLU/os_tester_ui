using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace os_tester_ui
{
    public class Result<T>
    {
        /// <summary>
        /// 状态码，0：失败，1：成功
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// 消息
        /// </summary>
        public string Msg { get; set; }

        /// <summary>
        /// 数据
        /// </summary>
        public T Data { get; set; }
    }

    public class Result : Result<object>
    {
        public static Result Succeed(string msg = "请求成功")
        {
            return new Result
            {
                Code = 1,
                Msg = msg
            };
        }

        public static Result<T> Succeed<T>(T data, string msg = "请求成功")
        {
            return new Result<T>
            {
                Code = 1,
                Msg = msg,
                Data = data
            };
        }

        public static Result Fail(string msg = "请求失败")
        {
            return new Result
            {
                Code = 0,
                Msg = msg
            };
        }

        public static Result<T> Fail<T>(string msg = "请求失败")
        {
            return new Result<T>
            {
                Code = 0,
                Msg = msg
            };
        }

        public static Result Ok()
        {
            return Succeed();
        }

        public static Result Ok(string msg)
        {
            return Succeed(msg);
        }

        public static Result<T> Ok<T>(T data)
        {
            return Succeed(data);
        }

        public static Result<T> Ok<T>(T data, string msg)
        {
            return Succeed(data, msg);
        }

        public static Result BadRequest()
        {
            return Fail();
        }

        public static Result BadRequest(string msg)
        {
            return Fail(msg);
        }

        public static Result<T> BadRequest<T>()
        {
            return Fail<T>();
        }

        public static Result<T> BadRequest<T>(string msg)
        {
            return Fail<T>(msg);
        }

        public static Result NotFound(string msg = "未找到对象")
        {
            return Fail(msg);
        }

        public static Result<T> NotFound<T>(string msg = "未找到对象")
        {
            return Fail<T>(msg);
        }
    }
}
