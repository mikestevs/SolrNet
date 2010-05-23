﻿#region license
// Copyright (c) 2007-2010 Mauricio Scheffer
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//      http://www.apache.org/licenses/LICENSE-2.0
//  
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
#endregion

using System;
using System.Globalization;

namespace SolrNet.Impl.QuerySerializers {
    public class RangeQuerySerializer : ISolrQuerySerializer {
        public bool CanHandleType(Type t) {
            return typeof (ISolrQueryByRange).IsAssignableFrom(t);
        }

        public string Serialize(object q) {
            var query = (ISolrQueryByRange) q;
            return "$field:$ii$from TO $to$if"
                            .Replace("$field", query.FieldName)
                            .Replace("$ii", query.Inclusive ? "[" : "{")
                            .Replace("$if", query.Inclusive ? "]" : "}")
                            .Replace("$from", Convert.ToString(query.From, CultureInfo.InvariantCulture))
                            .Replace("$to", Convert.ToString(query.To, CultureInfo.InvariantCulture));
        }
    }
}