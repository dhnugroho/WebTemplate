CREATE TABLE [dbo].[tb_r_travel_request_participant] (
    [id_request_participant] INT          IDENTITY (1, 1) NOT NULL,
    [no_reg_parent]          INT          NULL,
    [group_code]             VARCHAR (10) NULL,
    [no_reg]                 INT          NULL,
    [allowance_idr]          FLOAT (53)   NULL,
    [allowance_usd]          FLOAT (53)   NULL,
    [allowance_jpy]          FLOAT (53)   NULL,
    [created_date]           DATETIME     DEFAULT (getdate()) NULL,
    [modified_date]          DATETIME     NULL,
    [user_modified]          INT          NULL,
    [active_flag]            BIT          DEFAULT ((1)) NULL,
    PRIMARY KEY CLUSTERED ([id_request_participant] ASC)
);