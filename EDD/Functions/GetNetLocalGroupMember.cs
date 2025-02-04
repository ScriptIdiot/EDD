﻿using System;
using EDD.Models;

using System.Collections.Generic;

namespace EDD.Functions
{
    public class GetNetLocalGroupMember : EDDFunction
    {
        public override string FunctionName => "GetNetLocalGroupMember";

        public override string[] Execute(ParsedArgs args)
        {
            try
            {
                if (string.IsNullOrEmpty(args.ComputerName) || string.IsNullOrEmpty(args.GroupName))
                    throw new EDDException("ComputerName and GroupName cannot be empty");

                Amass shepherd = new Amass();
                List<string> localGroupMembers = shepherd.GetLocalGroupMembers(args.ComputerName, args.GroupName);
                return localGroupMembers.ToArray();
            }
            catch (Exception e)
            {
                return new string[] { "[X] Failure to enumerate info - " + e };
            }
        }
    }
}
