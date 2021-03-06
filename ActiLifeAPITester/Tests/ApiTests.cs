﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ActiLifeAPILibrary.Models.WearTimeValidation;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ActiLifeAPILibrary;

namespace ActiLifeAPITester.Tests
{
	internal class ApiTests
	{
		public abstract class TestBase : IApiTest
		{
			public TestBase()
			{

			}
			public TestBase(dynamic json)
			{
				_json = json;

				if (json != null)
					try { Name = json.Action; }
					catch (Microsoft.CSharp.RuntimeBinder.RuntimeBinderException) { }
			}

			#region IApiTest Members

			public string Name
			{
				get;
				protected set;
			}

			private dynamic _json = null;

			public virtual string GetJSON()
			{
				if (_json == null)
				{
					if (_json == null)
						throw new NotImplementedException();
				}

				JsonSerializerSettings dateFormattingSettings = new JsonSerializerSettings
				{
					Formatting = Newtonsoft.Json.Formatting.Indented,
					DateFormatHandling = DateFormatHandling.IsoDateFormat,
					DateTimeZoneHandling = DateTimeZoneHandling.Utc,
					Converters = new List<JsonConverter>() { new ActiLifeAPILibrary.Converters.JSONCustomDateConverter() }
				};

				return JsonConvert.SerializeObject(_json, dateFormattingSettings);
			}

			public virtual bool IsValidResponse(JObject d)
			{
				if (d == null) return false;

				if (!d.GetValueFromJToken<bool>("Success", false)) return false;

				JToken payload;
				if (d.TryGetValue("payload", StringComparison.CurrentCultureIgnoreCase, out payload))
					return IsValidPayload(payload);

				return true;
			}

			protected virtual bool IsValidPayload(JToken payload)
			{
				if (payload == null) return false; return true;
			}

			#endregion IApiTest Members
		}

		public class Tests
		{
			public class ActiLifeVersion : TestBase
			{
				public override string GetJSON()
				{
					return new ActiLifeAPILibrary.Models.Request.ActiLifeVersion().ToJson();
				}

				protected override bool IsValidPayload(JToken payload)
				{
					return payload.GetValueFromJToken<string>("version", null) != null;
				}
			}

			public class APIVersion : TestBase
			{
				public override string GetJSON()
				{
					return new ActiLifeAPILibrary.Models.Request.APIVersion().ToJson();
				}

				protected override bool IsValidPayload(JToken payload)
				{
					return payload.GetValueFromJToken<string>("version", null) != null;
				}
			}

			public class ActiLifeRestore : TestBase
			{
				public override string GetJSON()
				{
					return new ActiLifeAPILibrary.Models.Request.ActiLifeRestore().ToJson();
				}
			}

			public class ActiLifeMinimize : TestBase
			{
				public override string GetJSON()
				{
					return new ActiLifeAPILibrary.Models.Request.ActiLifeMinimize().ToJson();
				}
			}

			public class ActiLifeQuit : TestBase
			{
				public override string GetJSON()
				{
					return new ActiLifeAPILibrary.Models.Request.ActiLifeQuit().ToJson();
				}
			}

			public class NHANESWtv : TestBase
			{
				public NHANESWtv() : base() { }

				public override string GetJSON()
				{
					var assemblyDir = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

					return new ActiLifeAPILibrary.Models.Request.NHANESWTV
					{
						Options = new ActiLifeAPILibrary.Models.Actions.NhanesWtv
						{
							Filename = System.IO.Path.Combine(assemblyDir, "input.gt3x")
						}
					}.ToJson();
				}

				protected override bool IsValidPayload(JToken payload)
				{
					if (!base.IsValidPayload(payload)) return false;

					dynamic d = payload.GetValueFromJToken<dynamic>("results", null);

					if (d == null || d.NonWearBouts == null) return false;

					return true;
				}
			}

			public class DataScoring : TestBase
			{
				public override string GetJSON()
				{
					var assemblyDir = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

					return new ActiLifeAPILibrary.Models.Request.DataScoring
					{
						Options = new ActiLifeAPILibrary.Models.Actions.DataScoring
						{
							FileInputPath = System.IO.Path.Combine(assemblyDir, "input.agd")
						}
					}.ToJson();
				}
			}

            public class DataScoringExport : TestBase
            {
                public override string GetJSON()
                {
                    var assemblyDir = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

                    return new ActiLifeAPILibrary.Models.Request.DataScoringExport
                    {
                        Options = new ActiLifeAPILibrary.Models.Actions.DataScoringExport
                        {
                            FileInputPaths = new []{System.IO.Path.Combine(assemblyDir, "input.agd")},
                            ExportLocation = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                        }
                    }.ToJson();
                }
            }

			public class WearTimeValidation : TestBase
			{
				public override string GetJSON()
				{
					var assemblyDir = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

					return new ActiLifeAPILibrary.Models.Request.WearTimeValidation
					{
						Options = new ActiLifeAPILibrary.Models.Actions.WearTimeValidation
						{
							FileInputPath = System.IO.Path.Combine(assemblyDir, "input.agd"),
							Algorithm = "Choi",
							ChoiOptions = ChoiWTVOptions.Default,
							TroianoOptions = TroianoWTVOptions.Default
						}
					}.ToJson();
				}
			}

			public class ChangeWearTimeValidationPeriod : TestBase
			{
				public override string GetJSON()
				{
					var assemblyDir = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

					return new ActiLifeAPILibrary.Models.Request.ChangeWearTimeValidationPeriod
					{
						Options = new ActiLifeAPILibrary.Models.Actions.ChangeWearTimeValidationPeriod
						{
							FileInputPath = System.IO.Path.Combine(assemblyDir, "input.agd"),
							StartDateTime = DateTime.Now.Date,
							StopDateTime = DateTime.Now.Date.AddHours(1),
							IsWearPeriod = false
						}
					}.ToJson();
				}
			}

			public class ConvertFile : TestBase
			{
				public override string GetJSON()
				{
					var assemblyDir = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

					return new ActiLifeAPILibrary.Models.Request.ConvertFile
					{
						Options = new ActiLifeAPILibrary.Models.Actions.ConvertFile
						{
							FileInputPath = System.IO.Path.Combine(assemblyDir, "input.gt3x"),
							FileOutputPath = System.IO.Path.Combine(assemblyDir, "output.csv"),
							FileOutputFormat = "rawcsv"
						}
					}.ToJson();
				}
			}

			public class USBList : TestBase
			{
				public override string GetJSON()
				{
					return new ActiLifeAPILibrary.Models.Request.USBList().ToJson();
				}
			}

			public class USBInitialize : TestBase
			{
				public override string GetJSON()
				{
					return new ActiLifeAPILibrary.Models.Request.USBInitialize
					{
						Options = new ActiLifeAPILibrary.Models.Actions.USBInitialize
						{
							Serial = "MOS123456789",
							BioData = new ActiLifeAPILibrary.Models.Actions.BioData { SubjectName = "Subject123" },
							InitOptions = new ActiLifeAPILibrary.Models.Actions.InitOptions { SubjectName = "Subject123" }
						}
					}.ToJson();
				}
			}

			public class USBIdentify : TestBase
			{
				public override string GetJSON()
				{
					return new ActiLifeAPILibrary.Models.Request.USBIdentify
					{
						Options = new ActiLifeAPILibrary.Models.Actions.USBIdentify
						{
							Serial = "MOS123456789"
						}
					}.ToJson();
				}
			}

			public class USBDownload : TestBase
			{
				public override string GetJSON()
				{
					var assemblyDir = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

					return new ActiLifeAPILibrary.Models.Request.USBDownload
					{
						Options = new ActiLifeAPILibrary.Models.Actions.USBDownload
						{
							Serial = "MOS123456789",
							FileOutputPath = System.IO.Path.Combine(assemblyDir, "output.csv"),
							AGDOptions = new ActiLifeAPILibrary.Models.Actions.AGDOptions
							{
								Axis = 3
							}
						}
					}.ToJson();
				}
			}

            public class WirelessBurst : TestBase
            {
                public override string GetJSON()
                {
                    return new ActiLifeAPILibrary.Models.Request.WirelessBurst
                    {
                        Options = new ActiLifeAPILibrary.Models.Actions.WirelessBurst
                        {
                            AntID = "123",
                            Minutes = 15,
                            FileUseMetricUnits = false,
                            FileFormat = "agd",
                            FileOutPutPath = @"C:\BurstFolder\test.bin",
                            AntPIN = "1234",
                            TimeoutSeconds = 60
                        }
                    }.ToJson();
                }
            }

            public class WirelessIdentify : TestBase
            {
                public override string GetJSON()
                {
                    return new ActiLifeAPILibrary.Models.Request.WirelessIdentify
                    {
                        Options = new ActiLifeAPILibrary.Models.Actions.WirelessIdentify
                        {
                            AntID = "123",
                            AntPIN = "1234",
                            TimeoutSeconds = 30
                        }
                    }.ToJson();
                }
            }

            public class WirelessRealtimeStart : TestBase
            {
                public override string GetJSON()
                {
                    return new ActiLifeAPILibrary.Models.Request.WirelessRealtimeStart
                    {
                        Options = new ActiLifeAPILibrary.Models.Actions.WirelessRealtimeStart
                        {
                            AntID = "123",
                            AntPIN = "1234",
                            TimeoutSeconds = 30
                        }
                    }.ToJson();
                }
            }

            public class WirelessRealtimeStop : TestBase
            {
                public override string GetJSON()
                {
                    return new ActiLifeAPILibrary.Models.Request.WirelessRealtimeStop
                    {
                        Options = new ActiLifeAPILibrary.Models.Actions.WirelessRealtimeStop
                        {
                            AntID = "123"
                        }
                    }.ToJson();
                }
            }

            public class WirelessStart : TestBase
            {
                public override string GetJSON()
                {
                    return new ActiLifeAPILibrary.Models.Request.WirelessStart
                    {
                        Options = new ActiLifeAPILibrary.Models.Actions.WirelessStart
                        {
                            AntPIN = "1234"
                        }
                    }.ToJson();
                }
            }

            public class WirelessStop : TestBase
            {
                public override string GetJSON()
                {
                    return new ActiLifeAPILibrary.Models.Request.WirelessStop().ToJson();
                }
            }

            public class WirelessInitialize : TestBase
            {
                public override string GetJSON()
                {
                    return new ActiLifeAPILibrary.Models.Request.WirelessInitialize
                    {
                        AntID = "123",
                        AntPIN = "1234",
                        TimeoutSeconds = 30,
                        BioData = new ActiLifeAPILibrary.Models.Actions.BioData { SubjectName = "Subject123" },
                        InitOptions = new ActiLifeAPILibrary.Models.Actions.InitOptions { SubjectName = "Subject123" }
                    }.ToJson();
                }
            }
		}
	}
}
