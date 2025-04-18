namespace Foster.Framework;

/// <summary>
/// Stores information required to submit a draw command.
/// Call <see cref="Submit"/> or <see cref="GraphicsDevice.Draw"/> to submit.
/// </summary>
public struct DrawCommand
{
	/// <summary>
	/// Render Target. If not assigned, will target the Back Buffer
	/// </summary>
	public IDrawableTarget Target;

	/// <summary>
	/// Material to use
	/// </summary>
	public Material Material;

	/// <summary>
	/// Mesh to use
	/// </summary>
	public Mesh Mesh;

	/// <summary>
	/// The Index to begin rendering from the Mesh
	/// </summary>
	public int MeshIndexStart = 0;

	/// <summary>
	/// The total number of Indices to draw from the Mesh
	/// </summary>
	public int MeshIndexCount;

	/// <summary>
	/// The Offset into the Vertex Buffer
	/// </summary>
	public int MeshVertexOffset;

	/// <summary>
	/// The Render State Blend Mode
	/// </summary>
	public BlendMode BlendMode = BlendMode.Premultiply;

	/// <summary>
	/// The Render State Culling Mode
	/// </summary>
	public CullMode CullMode = CullMode.None;

	/// <summary>
	/// The Depth Comparison Function, only used if DepthTestEnabled is true
	/// </summary>
	public DepthCompare DepthCompare = DepthCompare.Less;

	/// <summary>
	/// If the Depth Test is enabled
	/// </summary>
	public bool DepthTestEnabled = false;

	/// <summary>
	/// If Writing to the Depth Buffer is enabled
	/// </summary>
	public bool DepthWriteEnabled = false;

	/// <summary>
	/// Render Viewport
	/// </summary>
	public RectInt? Viewport = null;

	/// <summary>
	/// The Render State Scissor Rectangle
	/// </summary>
	public RectInt? Scissor = null;

	/// <summary>
	/// Creates a Draw Command based on the given mesh and material
	/// </summary>
	public DrawCommand(IDrawableTarget target, Mesh mesh, Material material)
		: this()
	{
		Target = target;
		Mesh = mesh;
		Material = material;
		MeshIndexStart = 0;
		MeshIndexCount = mesh.IndexCount;
	}

	public readonly void Submit(GraphicsDevice graphicsDevice)
		=> graphicsDevice.Draw(this);
}