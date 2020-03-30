using System;
using System.Xml.Serialization;

namespace Utils
{
	[XmlRoot("ResponseData")]
	[Serializable]
	public class ResponseDataHelper2<T>
	{
		public ResponseDataHelper2()
		{
			this._responseCode = 0;
			this._responseMessage = "操作成功";
		}

		public PagerHelper PagerData { get; set; }

		public object PagerSummary { get; set; }

		public T ResponseData { get; set; }
		public int ResponseCode
		{
			get
			{
				return this._responseCode;
			}
			set
			{
				this._responseCode = value;
			}
		}




		public string ResponseMessage
		{
			get
			{
				return this._responseMessage;
			}
			set
			{
				this._responseMessage = value;
			}
		}


		private int _responseCode;


		private string _responseMessage = string.Empty;
	}
}