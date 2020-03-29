namespace Utils
{
	public class ResponseDataHelper
	{
		public ResponseDataHelper()
		{
			this._responseCode = 0;
			this._responseMessage = "操作成功";
		}

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