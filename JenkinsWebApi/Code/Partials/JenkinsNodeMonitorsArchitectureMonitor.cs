﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace JenkinsWebApi.Model
{
    public class JenkinsNodeMonitorsArchitectureMonitor
    {
        [XmlText]
        public string Architecture { get; set; }
    }
}