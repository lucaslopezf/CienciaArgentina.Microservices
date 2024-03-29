﻿using System;
using Microsoft.WindowsAzure.Storage.Table;

namespace CienciaArgentina.Microservices.Storage.Azure.TableStorage
{
	public class AppExceptionData : TableEntity
    {
        public AppExceptionData() { }

        public AppExceptionData(string id, DateTime date)
        {
            PartitionKey = date.ToString("yyyyMMdd");
            RowKey = $"{date:HHmmssfffffff}-{id}";
            Id = id;
            Date = date.ToUniversalTime();
        }

        public DateTime Date { get; set; } = DateTime.Now;
        public string Id { get; set; }

        public string CustomMessage { get; set; }
        public string Url { get; set; }
        public string UrlReferrer { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }
        public string IdFront { get; set; }

        public string Source { get; set; }
    }
}