using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.IO;

namespace AOPTest
{
   public  class msJsonSertest
    {
        public msJsonSertest()
        {

            object o = new TagCategoryDto();

            var s = (TagCategoryDto)o;
            // System.Runtime.Serialization.
            TagCategoryDto p = new TagCategoryDto()
            {
                CategoryName = "个性",
                Id = 1
            };

            
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(p.GetType());
            string jsonText;

            using (MemoryStream stream = new MemoryStream())
            {
                var dd = JsonReaderWriterFactory.CreateJsonWriter(stream);
               // dd.WriteString()
               

                serializer.WriteObject(stream, p);
                jsonText = Encoding.UTF8.GetString(stream.ToArray());
                Console.WriteLine(jsonText);
            }

            using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(jsonText)))
            {
                DataContractJsonSerializer serializer1 = new DataContractJsonSerializer(typeof(TagCategoryDto));
                TagCategoryDto p1 = (TagCategoryDto)serializer1.ReadObject(ms);
                Console.WriteLine(p1.Code + "=>" + p1.Code);
            }
        }

        public class TagCategoryDto
        {
            ///<summary>
            /// 标签分类编号
            ///</summary>
            public int Id { get; set; }

            ///<summary>
            /// 标签分类名
            ///</summary>
            public string CategoryName { get; set; }


            private int _code=-1;
            /// <summary>
            /// Code
            /// </summary>
            public int Code
            {
               
                get
                {
                    switch (CategoryName)
                    {
                        case "个性": _code = 1;
                            break;

                        case "生活": _code = 2;
                            break;

                        case "兴趣": _code = 3;
                            break;

                        default:
                            break;
                    }

                    return _code;
                }

                set { _code = value; }
            }



        }

       
    }
}
