﻿//-------------------------------------------------------------------------------------------------
// Name        : SegmentGetAllQueryResponse
// Type        : Class
// Author      : Kevin McGregor
// History     : 31-Mar-25 - Created
// Description :
// Copyright   : This is the property of Escape Software Solutions Limited and cannot be used, 
//               copied or modified without the express permission of the company in 
//               in writing. Copyright 2025 Escape Software Solutions Limited.
//-------------------------------------------------------------------------------------------------
using ProductSales.Application.DTOs;

namespace ProductSales.Application.CQRS.Responses;

public class SegmentGetAllQueryResponse
{
    public IEnumerable<SegmentDTO>? Segments { get; set; }
}
