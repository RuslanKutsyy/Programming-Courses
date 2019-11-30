using System;
using System.Collections.Generic;
using System.Text;

namespace P01.Stream_Progress
{
    public interface IStream
    {
        int Length { get; set; }

        int BytesSent { get; set; }
    }
}
